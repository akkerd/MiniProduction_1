using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

class BeforeBuild : IPreprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }
    public void OnPreprocessBuild(BuildReport report)
    {
        //Debug.Log("MyCustomBuildProcessor.OnPreprocessBuild for target " + report.summary.platform + " at path " + report.summary.outputPath);
        if (Application.productName.ToString().Contains("dev"))
        {
            PlayerSettings.productName = "testing_" + Application.version.ToString();            
        }
        else
        {
            PlayerSettings.productName = "master_" + Application.version.ToString();
        }        
    }
}
