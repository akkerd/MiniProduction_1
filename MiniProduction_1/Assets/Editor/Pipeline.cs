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
            if (Application.identifier.ToString().Contains("dev"))
            {
                PlayerSettings.productName = "testing_" + Application.version.ToString();
            }
            else
            {
                PlayerSettings.productName = "master_" + Application.version.ToString();
            }

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
                return "C:\\Users\\dadiu\\Dropbox\\DADIU_Team4\\Minigame1\\090_pipeline\\Apks\\";
            }
        }

        public static string filename
        {

            get
            {
                Debug.Log("here");
                if (Application.identifier.ToString().Contains("dev"))
                {
                    return ("testing_build" + ".apk");
                }
                else
                {
                    return ("master_build" + ".apk");
                }
            }
        }

    }
}