/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LoggerSample.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/21/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Autofac.InterfaceSample;
using UnityEngine;

namespace MGS.Autofac.ImplementSample
{
    [AutofacRegister]
    class LoggerSample : ILoggerSample
    {
        public void Log(string message)
        {
            Debug.Log($"LoggerSample: GetHashCode {GetHashCode()} message {message}");
        }
    }

    [AutofacRegister(Singleton = true)]
    class LoggerSampleA : ILoggerSampleA
    {
        public void Log(string message)
        {
            Debug.Log($"LoggerSampleA: GetHashCode {GetHashCode()} message {message}");
        }
    }

    [AutofacRegister(Singleton = true, ServiceKey = "B_A", ServiceType = typeof(ILoggerSampleB))]
    class LoggerSampleB_A : ILoggerSampleB
    {
        public void Log(string message)
        {
            Debug.Log($"LoggerSampleB_A: GetHashCode {GetHashCode()} message {message}");
        }
    }

    [AutofacRegister(Singleton = true, ServiceKey = "B_B", ServiceType = typeof(ILoggerSampleB))]
    class LoggerSampleB_B : ILoggerSampleB
    {
        public void Log(string message)
        {
            Debug.Log($"LoggerSampleB_B: GetHashCode {GetHashCode()} message {message}");
        }
    }
}