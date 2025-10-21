/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  AutofacResolveSample.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/21/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using MGS.Autofac.InterfaceSample;
using UnityEngine;

namespace MGS.Autofac.ResolveSample
{
    public class AutofacResolveSample : MonoBehaviour
    {
        void Start()
        {
            Debug.Log("------------Singleton = false------------");
            var logger00 = AutofacUtility.Resolve<ILoggerSample>();
            logger00.Log("Test logger00");

            var logger01 = AutofacUtility.Resolve<ILoggerSample>();
            logger01.Log("Test logger01");

            Debug.Log("------------Singleton = true------------");
            var logger10 = AutofacUtility.Resolve<ILoggerSampleA>();
            logger10.Log("Test logger10");

            var logger11 = AutofacUtility.Resolve<ILoggerSampleA>();
            logger11.Log("Test logger11");

            Debug.Log("------------Singleton = true & ServiceKey------------");
            var logger20 = AutofacUtility.ResolveKeyed<ILoggerSampleB>("B_A");
            logger20.Log("Test logger20");

            var logger21 = AutofacUtility.ResolveKeyed<ILoggerSampleB>("B_B");
            logger21.Log("Test logger21");
        }
    }
}