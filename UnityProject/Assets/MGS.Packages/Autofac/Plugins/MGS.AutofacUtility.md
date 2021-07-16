[TOC]

﻿# MGS.AutofacUtility.dll

## Summary
- Utility for project develop with Autofac. 

## Environment

- .Net Framework 3.5 or above.

## Dependence

- System.dll
- Autofac.dll

## Demand
- Auto register the mark types.
- Resolve mark type anywhere.

## Implement
### AutofacRegisterAttribute
- Mark a type need register for interface.

### AutofacUtility
- Register mark types to Autofac Container.
- Resolve the instance of target interface.

## Usage

- Define interface.

  ```c#
  public interface ITest
  {
      void DoTest();
  }
  ```

- Use AutofacRegisterAttribute to mark a type need register for target interface.

  ```c#
  [AutofacRegister]
  internal class Test : ITest
  {
      public void DoTest(){}
  }
  
  // Use ServiceKey to mark type; you can resolve instance of this type by ServiceKey.
  [AutofacRegister(ServiceKey = "Debug", ServiceType = typeof(ITest))]
  internal class TestDebug : ITest
  {
      public void DoTest(){}
  }
  ```
  
- Use AutofacUtility.Register to register the mark types.

  ```C#
  // Register the mark types defined in assemblies of current app domain.
  AutofacUtility.Register();
  
  // Register the mark types defined in assemblies.
  AutofacUtility.Register(IEnumerable<Assembly> assemblies);
  
  // Register the mark types.
  AutofacUtility.Register(IEnumerable<Type> types);
  
  // Register the mark types from infos;
  // key is name of assembly, value is names collection of mark types.
  AutofacUtility.Register(IDictionary<string, ICollection<string>> infos);
  ```
  
  
  
- Use AutofacUtility.Resolve to get the instance of the mark type.

  ```c#
  // The instance is Test.
  var test = AutofacUtility.Resolve<ITest>();
  test.DoTest();
  
  // The instance is TestDebug.
  var testDebug = AutofacUtility.ResolveKeyed<ITest>("Debug");
  testDebug.DoTest();
  ```
------

[Previous](../../README.md)

------

Copyright © 2021 Mogoson.	mogoson@outlook.com