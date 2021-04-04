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

- Use AutofacRegisterAttribute to mark a type need register.

  ```c#
  public interface IDebugA
  {
      void DebugLog(string msg);
  }
  
  [AutofacRegister(Singleton = true)]
  internal class DebugA : IDebugA
  {
      public void DebugLog(string msg)
      {
          Debug.Log(msg);
      }
  }
  ```
- Use AutofacUtility.Resolve to get the instance of the mark type.

  ```c#
  var debugA = AutofacUtility.Resolve<IDebugA>();
  debugA.DebugLog("Test Resolve IDebugA");
  ```
## Contact
- If you have any questions, feel free to contact me at mogoson@outlook.com.