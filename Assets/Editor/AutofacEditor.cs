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
using System.Linq;
using UnityEditor;

namespace MGS.Autofac.Editors
{
    public class AutofacEditor : AssetPostprocessor
    {
        const string NAME_CONFIGURATOR = "AutofacConfigurator";

        const string TAG_COPYRIGHT_YEAR = "#COPYRIGHTYEAR#";
        const string TAG_CREATE_DATE = "#CREATEDATE#";
        const string TAG_REGISTER_CODES = "/*REGISTERCODES*/";

        [UnityEditor.Callbacks.DidReloadScripts]
        static void OnDidReloadScripts()
        {
            UpdateConfigurator();
        }

        static void UpdateConfigurator()
        {
            var registerCodes = string.Empty;
            var infos = SearchRegisterInfos();
            if (infos.Count > 0)
            {
                registerCodes = BuildRegisterCodes(infos);
            }

            var configurator = ReadConfiguratorTemplate();
            configurator = configurator.Replace(TAG_COPYRIGHT_YEAR, DateTime.Now.Year.ToString());
            configurator = configurator.Replace(TAG_CREATE_DATE, DateTime.Now.ToString("MM/dd/yyyy"));
            configurator = configurator.Replace(TAG_REGISTER_CODES, registerCodes);
            OverwriteConfiguratorClass(configurator);
        }

        static string ReadConfiguratorTemplate()
        {
            var templatePath = $"{ResolveEditorDir()}/{NAME_CONFIGURATOR}.txt";
            return File.ReadAllText(templatePath);
        }

        static void OverwriteConfiguratorClass(string configurator)
        {
            var configuratorPath = $"{ResolveRuntimeDir()}/{NAME_CONFIGURATOR}.cs";
            File.WriteAllText(configuratorPath, configurator);
            AssetDatabase.Refresh();
        }

        static string ResolveEditorDir()
        {
            return ResolveFileDir($"{nameof(AutofacEditor)}.cs");
        }

        static string ResolveRuntimeDir()
        {
            return ResolveFileDir($"{nameof(AutofacUtility)}.cs");
        }

        static string ResolveFileDir(string fileName)
        {
            var filePath = AssetDatabase.GetAllAssetPaths().First(path => path.Contains(fileName));
            return Path.GetDirectoryName(filePath);
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
                        types.Add($"{type.FullName}");
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
                    typeCodeLines += $"\r\n                \"{typeName}\",";
                }

                var typeListCodes = $"new List<string>(){{{typeCodeLines}}}";
                codes += $"{{\"{assemblyName}\", {typeListCodes}\r\n            }},\r\n";
            }
            return codes;
        }
    }
}