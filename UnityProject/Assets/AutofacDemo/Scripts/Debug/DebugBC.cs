/*************************************************************************
 *  Copyright (c) 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DebugBC.cs
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
    [AutofacRegister(Singleton = true)]
    internal class DebugBC : IDebugB, IDebugC
    {
        public void DebugError(string msg)
        {
            Debug.LogError(msg);
        }

        public void DebugWarning(string msg)
        {
            Debug.LogWarning(msg);
        }
    }
}