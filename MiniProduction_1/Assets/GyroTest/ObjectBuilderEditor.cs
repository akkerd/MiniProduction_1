using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SpringObject))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        SpringObject myScript = (SpringObject)target;
        if(GUILayout.Button("Reset Everything"))
        {
            myScript.ResetEverything();
        }
    }
}