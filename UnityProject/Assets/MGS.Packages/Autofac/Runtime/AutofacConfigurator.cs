/*************************************************************************
 *  Copyright © 2022 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  AutofacConfigurator.cs
 *  Description  :  Runtime configurator for Autofac.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.0.0.0
 *  Date         :  11/30/2022
 *  Description  :  The codes auto create by AutofacEditor.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace Autofac
{
    /// <summary>
    /// Runtime configurator for Autofac.
    /// </summary>
    public sealed class AutofacConfigurator
    {
        /// <summary>
        /// Awake Configurator.
        /// </summary>
#if UNITY_5_3 || UNITY_5_3_OR_NEWER
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
#else
        [RuntimeInitializeOnLoadMethod]
#endif
        private static void Awake()
        {
            AutofacUtility.Register(registerInfos);
            registerInfos = null;
        }

        /// <summary>
        /// Register infos(assemblyName, typeNames)
        /// </summary>
        private static IDictionary<string, ICollection<string>> registerInfos = new Dictionary<string, ICollection<string>>()
        {
            {"Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", new List<string>(){
                "Autofac.Demo.DebugA",
                "Autofac.Demo.DebugB",
                "Autofac.Demo.DebugC0",
                "Autofac.Demo.DebugC1",}
            },

        };
    }
}