[TOC]

# MGS.Autofac

## Summary
- Toolkit for Unity project develop with Autofac. 

## Ability
- Auto register the mark types.
- Resolve mark type anywhere.

## Install

- Unity --> Window --> Package Manager --> "+" --> Add package from git URL...

  ```text
  https://github.com/mogoson/MGS.Autofac.git?path=/Assets
  ```

## Scheme
### Config
- AutofacEditor auto search the register types mark by AutofacRegisterAttribute, and build the runtime config file(AutofacConfigurator.cs) on UnityEditor DidReloadScripts.

### Register
- AutofacConfigurator register the mark types to AutofacUtility(Build Autofac Container) by RuntimeInitializeOnLoadMethodAttribute on UnityEngine load.

## Samples

- Unity --> Window --> Package Manager --> Packages-Mogoson --> Autofac --> Samples.

------

Copyright © 2025 Mogoson.	mogoson@outlook.com