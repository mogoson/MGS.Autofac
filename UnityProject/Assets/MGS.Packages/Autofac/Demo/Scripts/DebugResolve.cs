/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DebugResolve.cs
 *  Description  :  Null.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  1/23/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Autofac.Demo
{
    public class DebugResolve : MonoBehaviour
    {
        void Start()
        {
            var debugA = AutofacUtility.Resolve<IDebugA>();
            debugA.DebugLog("Test Resolve.");

            var debugB = AutofacUtility.Resolve<IDebugB>();
            debugB.DebugWarning("Test Resolve.");

            var debugC0 = AutofacUtility.ResolveKeyed<IDebugC>("C0");
            debugC0.DebugError("Test Resolve.");

            var debugC1 = AutofacUtility.ResolveKeyed<IDebugC>("C1");
            debugC1.DebugError("Test Resolve.");
        }
    }
}