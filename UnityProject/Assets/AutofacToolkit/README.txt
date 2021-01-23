==================================
  Copyright © 2021 Mogoson. All rights reserved.
  Name: AutofacToolkit
  Author: Mogoson   Version: 1.0.0   Date: 1/23/2021
==================================

Summary
- Toolkit for Unity project develop with Autofac. 
--------------------------------------------------------------------------
Demand
- Auto register the mark types.
- Resolve mark type anywhere.
--------------------------------------------------------------------------
Environment
- Unity 5.0 or above.
- .Net Framework 3.5 or above.
--------------------------------------------------------------------------
Implement
  Config
  - AutofacEditor auto search the register types mark by AutofacRegisterAttribute, 
    and build the runtime config file(AutofacConfigurator.cs) on UnityEditor DidReloadScripts.

  Register
  - AutofacConfigurator register the mark types to AutofacUtility(Build Autofac
    Container) by RuntimeInitializeOnLoadMethodAttribute on UnityEngine load.
--------------------------------------------------------------------------
Usage
- Use AutofacRegisterAttribute to mark a type need register.
- Use AutofacUtility.Resolve to get the instance of the mark type.
--------------------------------------------------------------------------
Resource
- https://github.com/mogoson/AutofacToolkit.
--------------------------------------------------------------------------
Contact
- If you have any questions, feel free to contact me at mogoson@outlook.com.
--------------------------------------------------------------------------