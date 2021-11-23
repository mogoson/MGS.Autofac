/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DebugResolveDemo.cs
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
    public class DebugResolveDemo : MonoBehaviour
    {
        void Start()
        {
            var debugA = AutofacUtility.Resolve<IDebugA>();
            debugA.DebugLog("Test Resolve IDebugA.");

            var debugB = AutofacUtility.Resolve<IDebugB>();
            debugB.DebugWarning("Test Resolve IDebugB.");

            var debugC0 = AutofacUtility.ResolveKeyed<IDebugC>("C0");
            debugC0.DebugError("Test Resolve IDebugC C0.");

            var debugC1 = AutofacUtility.ResolveKeyed<IDebugC>("C1");
            debugC1.DebugError("Test Resolve IDebugC C1.");
        }
    }
}