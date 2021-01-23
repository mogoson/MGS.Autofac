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

## Contact
- If you have any questions, feel free to contact me at mogoson@outlook.com.