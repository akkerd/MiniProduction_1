using System;
using System.IO;
using System.Linq;
using UnityEngine;



namespace UnityEditor
{
    public class Pipeline 
    {
        [MenuItem("Pipeline/Build: Android")]

        public static void BuildAndroid()
        {
            var result = BuildPipeline.BuildPlayer(new BuildPlayerOptions
            {
                
                locationPathName = Path.Combine(pathname, filename),
                scenes = EditorBuildSettings.scenes.Where(n => n.enabled).Select(n => n.path).ToArray(),
                target = BuildTarget.Android
            });
            Debug.Log(result);
        }

        public static string pathname
        {
            

            get
            {
                return (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "builds"));
            }
        }

        public static string filename
        {

            get
            {
                return ("Build" + ".apk");
            }
        }

    }
}