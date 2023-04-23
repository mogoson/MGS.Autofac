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
        const string NAME_CONFIGURATOR = "AutofacConfigurator";

        const string TAG_COPYRIGHT_YEAR = "#COPYRIGHTYEAR#";
        const string TAG_CREATE_DATE = "#CREATEDATE#";
        const string TAG_REGISTER_CODES = "/*REGISTERCODES*/";

        const string KEY_IGNORE = "IGNORE_UPDATE_CONFIGURATOR";

        [UnityEditor.Callbacks.DidReloadScripts]
        static void OnDidReloadScripts()
        {
            if (EditorPrefs.GetBool(KEY_IGNORE))
            {
                EditorPrefs.SetBool(KEY_IGNORE, false);
                return;
            }

            UpdateConfigurator();
            EditorPrefs.SetBool(KEY_IGNORE, true);
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
            configurator = configurator.Replace(TAG_CREATE_DATE, DateTime.Now.ToShortDateString());
            configurator = configurator.Replace(TAG_REGISTER_CODES, registerCodes);
            OverwriteConfiguratorClass(configurator);
        }

        static string ReadConfiguratorTemplate()
        {
            var editorClass = $"{typeof(AutofacEditor).Name}.cs";
            var editorPath = AssetDatabase.GetAllAssetPaths().First(path => { return path.Contains(editorClass); });
            var templatePath = editorPath.Replace(editorClass, $"{NAME_CONFIGURATOR}.txt");
            return AssetDatabase.LoadAssetAtPath<TextAsset>(templatePath).text;
        }

        static void OverwriteConfiguratorClass(string configurator)
        {
            var configuratorAsset = $"Assets/{NAME_CONFIGURATOR}.txt";
            AssetDatabase.CreateAsset(new TextAsset(), configuratorAsset);

            var configuratorTempPath = $"{Application.dataPath}/../{configuratorAsset}";
            File.WriteAllText(configuratorTempPath, configurator);

            var utilityClass = $"{typeof(AutofacUtility).Name}.cs";
            var utilityPath = AssetDatabase.GetAllAssetPaths().First(path => { return path.Contains(utilityClass); });
            var configuratorPath = utilityPath.Replace(utilityClass, $"{NAME_CONFIGURATOR}.cs");

            AssetDatabase.DeleteAsset(configuratorPath);
            AssetDatabase.CopyAsset(configuratorAsset, configuratorPath);
            AssetDatabase.DeleteAsset(configuratorAsset);
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