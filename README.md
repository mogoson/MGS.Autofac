[TOC]

# MGS.Autofac

## Summary
- Toolkit for Unity project develop with Autofac. 

## Environment

- Unity 5.0 or above.
- .Net Framework 3.5 or above.

## Demand
- Auto register the mark types.
- Resolve mark type anywhere.

## Implement
### Config
- AutofacEditor auto search the register types mark by AutofacRegisterAttribute, and build the runtime config file(AutofacConfigurator.cs) on UnityEditor DidReloadScripts.

### Register
- AutofacConfigurator register the mark types to AutofacUtility(Build Autofac Container) by RuntimeInitializeOnLoadMethodAttribute on UnityEngine load.

### Usage

- Reference

  If you need use AutofacUtility in dll：

  - Create a C# project, move the AutofacRegisterAttribute.cs and AutofacUtility.cs files into the project.
  - Compile project as dll to reference.

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

------

Copyright © 2021 Mogoson. All rights reserved.	mogoson@outlook.com