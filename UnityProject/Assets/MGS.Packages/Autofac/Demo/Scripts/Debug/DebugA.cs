/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  DebugA.cs
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
    [AutofacRegister]
    internal class DebugA : IDebugA
    {
        public void DebugLog(string msg)
        {
            Debug.Log("DebugA: " + msg);
        }
    }
}