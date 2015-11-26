using UnityEngine;
using UnityEditor;

public class SPPSetting : EditorWindow
{
    public SPPEditorScript MyScript;

    const string assetPath = "Assets/SecurePlayerPrefs/Resources/SPPEditorScript.asset";

    [MenuItem("Window/SecurePlayerPrefs")]
    public static void init()
    {
        SPPSetting window = (SPPSetting)GetWindow(typeof(SPPSetting));
        window.Show();
    }

    void OnEnable()
    {
        MyScript = (SPPEditorScript)AssetDatabase.LoadAssetAtPath(assetPath, typeof(SPPEditorScript));

        if (MyScript == null)
        {
            MyScript = ScriptableObject.CreateInstance<SPPEditorScript>();
            AssetDatabase.CreateAsset(MyScript, assetPath);
            AssetDatabase.SaveAssets();
        }        
    }

    public void OnGUI()
    {
        MyScript.password = EditorGUILayout.TextField("Password", MyScript.password);
        MyScript.encryption = (SecurePlayerPrefs.EncryptionType)EditorGUILayout.EnumPopup("Encryption", MyScript.encryption);
        MyScript.bounce = EditorGUILayout.IntField("# of hashing keys", MyScript.bounce);

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Set Default"))
        {
            MyScript.SetDefault();
            SaveAsset();
        }
        if (GUILayout.Button("Save"))
        {
            MyScript.Save();
            SaveAsset();
        }
        EditorGUILayout.EndHorizontal();
    }

    void SaveAsset()
    {
        EditorUtility.SetDirty(MyScript);
        AssetDatabase.SaveAssets();
    }

}
