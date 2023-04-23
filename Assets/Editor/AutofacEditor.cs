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
using UnityEngine;

namespace Autofac.Editors
{
    public class AutofacEditor : AssetPostprocessor
    {
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
            configurator = configurator.Replace("#COPYRIGHTYEAR#", DateTime.Now.Year.ToString());
            configurator = configurator.Replace("#CREATEDATE#", DateTime.Now.ToShortDateString());
            configurator = configurator.Replace("/*REGISTERCODES*/", registerCodes);
            OverwriteConfiguratorClass(configurator);
        }

        static string ReadConfiguratorTemplate()
        {
            var editorClass = $"{typeof(AutofacEditor).Name}.cs";
            var editorPath = AssetDatabase.GetAllAssetPaths().First(path => { return path.Contains(editorClass); });
            var templatePath = editorPath.Replace(editorClass, "AutofacConfigurator.txt");
            return AssetDatabase.LoadAssetAtPath<TextAsset>(templatePath).text;
        }

        static void OverwriteConfiguratorClass(string configurator)
        {
            var configuratorPath = $"{Application.dataPath}/Scripts/AutofacConfigurator.cs";
            var configuratorDir = Path.GetDirectoryName(configuratorPath);
            if (!Directory.Exists(configuratorDir))
            {
                Directory.CreateDirectory(configuratorDir);
            }
            File.WriteAllText(configuratorPath, configurator);
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