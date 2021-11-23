/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DebugB.cs
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
    internal class DebugB : IDebugB
    {
        public void DebugWarning(string msg)
        {
            Debug.LogWarning("DebugB: " + msg);
        }
    }
}