/*************************************************************************
 *  Copyright © 2021 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  AutofacEditor.cs
 *  Description  :  Editor for AutofacConfig.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  1/21/2021
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Autofac.Editors
{
    public class AutofacEditor : AssetPostprocessor
    {
        static readonly string CONFIGURATOR_TEMPLATE_FILE_PATH = string.Format("{0}/MGS.Packages/Autofac/Editor/AutofacConfigurator.txt", Application.dataPath);
        static readonly string CONFIGURATOR_RUNTIME_FILE_PATH = string.Format("{0}/MGS.Packages/Autofac/Runtime/Scripts/AutofacConfigurator.cs", Application.dataPath);
        const string COPYRIGHT_YEAR = "#COPYRIGHTYEAR#";
        const string CREATE_DATE = "#CREATEDATE#";
        const string REGISTER_CODES = "/*REGISTERCODES*/";

        [UnityEditor.Callbacks.DidReloadScripts]
        static void OnDidReloadScripts()
        {
            UpdateConfigurator();
        }

        static void UpdateConfigurator()
        {
            var registerCodes = REGISTER_CODES;
            var infos = SearchRegisterInfos();
            if (infos.Count > 0)
            {
                registerCodes = BuildRegisterCodes(infos);
            }

            var configurator = File.ReadAllText(CONFIGURATOR_TEMPLATE_FILE_PATH);
            configurator = configurator.Replace(COPYRIGHT_YEAR, DateTime.Now.Year.ToString());
            configurator = configurator.Replace(CREATE_DATE, DateTime.Now.ToShortDateString());
            configurator = configurator.Replace(REGISTER_CODES, registerCodes);

            var configuratorDir = Path.GetDirectoryName(CONFIGURATOR_RUNTIME_FILE_PATH);
            if (!Directory.Exists(configuratorDir))
            {
                Directory.CreateDirectory(configuratorDir);
            }

            File.WriteAllText(CONFIGURATOR_RUNTIME_FILE_PATH, configurator);
            AssetDatabase.Refresh();
        }

        static IDictionary<string, ICollection<string>> SearchRegisterInfos()
        {
            var infos = new Dictionary<string, ICollection<string>>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = new List<string>();
                foreach (var type in assembly.GetTypes())
                {
                    if (Attribute.IsDefined(type, typeof(AutofacRegisterAttribute)))
                    {
                        types.Add(string.Format("{0}", type.FullName));
                    }
                }

                if (types.Count > 0)
                {
                    infos[assembly.FullName] = types;
                }
            }
            return infos;
        }

        static string BuildRegisterCodes(IDictionary<string, ICollection<string>> infos)
        {
            var codes = string.Empty;
            foreach (var assemblyName in infos.Keys)
            {
                var types = infos[assemblyName];
                var typeCodeLines = string.Empty;
                foreach (var typeName in types)
                {
                    typeCodeLines += string.Format("\r\n                \"{0}\",", typeName);
                }

                var typeListCodes = string.Format("new List<string>(){{{0}}}", typeCodeLines);
                codes += string.Format("{{\"{0}\", {1}\r\n            }},\r\n", assemblyName, typeListCodes);
            }
            return codes;
        }
    }
}