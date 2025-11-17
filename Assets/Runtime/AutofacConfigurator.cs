/*************************************************************************
 *  Copyright © 2025 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  AutofacConfigurator.cs
 *  Description  :  Runtime configurator for Autofac.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.0.0.0
 *  Date         :  11/17/2025
 *  Description  :  The codes auto create by AutofacEditor.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace MGS.Autofac
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
            
        };
    }
}