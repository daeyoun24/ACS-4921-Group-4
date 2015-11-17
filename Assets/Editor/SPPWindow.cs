using UnityEngine;
using UnityEditor;

public class SPPWindow : EditorWindow
{
    string myPassword;
    bool groupEnabled;
    bool useAES;

    [MenuItem("Window/SecurePlayerPrefs")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SPPWindow));
    }    

    void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("password");
        myPassword = EditorGUILayout.PasswordField(myPassword);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        useAES = EditorGUILayout.Toggle("AES [default: DES]", useAES);
        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.Space();

        EditorGUILayout.HelpBox("It's a help box", MessageType.Info);
    }
}
