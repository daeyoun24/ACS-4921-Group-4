using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SPPEditorScript))]
public class SPPWindow : Editor
{
    public override void OnInspectorGUI()
    {
        SPPEditorScript targetScript = (SPPEditorScript)target;

        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("password");
        targetScript.password = EditorGUILayout.TextField(targetScript.password);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        targetScript.useAES = EditorGUILayout.Toggle("AES [default: DES]", targetScript.useAES);

        EditorGUILayout.Space();

        EditorGUILayout.HelpBox("It's a help box", MessageType.Info);
    }
}
