# AutofacToolkit

## Summary
- Toolkit for Unity project develop with Autofac. 

## Demand
- Auto register the mark types.
- Resolve mark type anywhere.

## Environment
- Unity 5.3 or above.
- .Net Framework 3.5 or above.

## Implement
### Config
- AutofacEditor auto search the register types mark by AutofacRegisterAttribute, and build the runtime config file(AutofacConfigurator.cs) on UnityEditor DidReloadScripts.

### Register
- AutofacConfigurator register the mark types to AutofacUtility(Build Autofac Container) by RuntimeInitializeOnLoadMethodAttribute on UnityEngine load.

### Usage

- Define interface.

  ```c#
  public interface ITest
  {
      void DoTest();
  }
  ```

- Use AutofacRegisterAttribute to mark a type need register.

  ```c#
  [AutofacRegister]
  internal class Test : ITest
  {
      public void DoTest(){}
  }
  
  [AutofacRegister(ServiceKey = "Debug", ServiceType = typeof(ITest))]
  internal class TestDebug : ITest
  {
      public void DoTest(){}
  }
  ```
- Use AutofacUtility.Resolve to get the instance of the mark type.

  ```c#
  var test = AutofacUtility.Resolve<ITest>();
  test.DoTest();
  
  var testDebug = AutofacUtility.ResolveKeyed<ITest>("Debug");
  testDebug.DoTest();
  ```
## Contact
- If you have any questions, feel free to contact me at mogoson@outlook.com.