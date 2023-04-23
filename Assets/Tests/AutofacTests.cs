using Autofac;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class AutofacTests
    {
        [Test]
        public void ResolveTest()
        {
            var logger0 = AutofacUtility.Resolve<ITestLogger>();
            logger0.Log("Test logger0");

            var logger1 = AutofacUtility.Resolve<ITestLogger>();
            logger1.Log("Test logger1");

            Assert.AreNotEqual(logger0.GetHashCode(), logger1.GetHashCode());
        }

        [Test]
        public void ResolveSingletonTest()
        {
            var logger0 = AutofacUtility.Resolve<ITestLogger1>();
            logger0.Log("Test logger0");

            var logger1 = AutofacUtility.Resolve<ITestLogger1>();
            logger1.Log("Test logger1");

            Assert.AreEqual(logger0.GetHashCode(), logger1.GetHashCode());
        }

        [Test]
        public void ResolveKeyedTest()
        {
            var logger0 = AutofacUtility.ResolveKeyed<ITestLogger2>("2_1");
            logger0.Log("Test logger0");

            var logger1 = AutofacUtility.ResolveKeyed<ITestLogger2>("2_2");
            logger1.Log("Test logger1");

            Assert.AreEqual(typeof(TestLogger2_1), logger0.GetType());
            Assert.AreEqual(typeof(TestLogger2_2), logger1.GetType());
        }

        #region 
        interface ITestLogger
        {
            void Log(string message);
        }

        interface ITestLogger1
        {
            void Log(string message);
        }

        interface ITestLogger2
        {
            void Log(string message);
        }

        [AutofacRegister]
        class TestLogger : ITestLogger
        {
            public void Log(string message)
            {
                Debug.Log($"TestLogger: GetHashCode {GetHashCode()} message {message}");
            }
        }

        [AutofacRegister(Singleton = true)]
        class TestLogger1 : ITestLogger1
        {
            public void Log(string message)
            {
                Debug.Log($"TestLogger1: GetHashCode {GetHashCode()} message {message}");
            }
        }

        [AutofacRegister(Singleton = true, ServiceKey = "2_1", ServiceType = typeof(ITestLogger2))]
        class TestLogger2_1 : ITestLogger2
        {
            public void Log(string message)
            {
                Debug.Log($"TestLogger2_1: GetHashCode {GetHashCode()} message {message}");
            }
        }

        [AutofacRegister(Singleton = true, ServiceKey = "2_2", ServiceType = typeof(ITestLogger2))]
        class TestLogger2_2 : ITestLogger2
        {
            public void Log(string message)
            {
                Debug.Log($"TestLogger2_2: GetHashCode {GetHashCode()} message {message}");
            }
        }
        #endregion
    }
}