/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DebugC.cs
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
    [AutofacRegister(ServiceKey = "C0", ServiceType = typeof(IDebugC))]
    internal class DebugC0 : IDebugC
    {
        public void DebugError(string msg)
        {
            Debug.LogError("DebugC0: " + msg);
        }
    }

    [AutofacRegister(ServiceKey = "C1", ServiceType = typeof(IDebugC))]
    internal class DebugC1 : IDebugC
    {
        public void DebugError(string msg)
        {
            Debug.LogError("DebugC1: " + msg);
        }
    }
}