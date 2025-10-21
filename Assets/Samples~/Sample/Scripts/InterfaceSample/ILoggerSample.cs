/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ILoggerSample.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  10/21/2025
 *  Description  :  Initial development version.
 *************************************************************************/

namespace MGS.Autofac.InterfaceSample
{
    public interface ILoggerSample
    {
        void Log(string message);
    }

    public interface ILoggerSampleA
    {
        void Log(string message);
    }

    public interface ILoggerSampleB
    {
        void Log(string message);
    }
}