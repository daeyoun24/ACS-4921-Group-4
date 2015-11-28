using UnityEngine;
using UnityEditor;

public class SPPSettings : EditorWindow
{
    public SPPEditorScript MyScript;

    const string assetPath = "Assets/SecurePlayerPrefs/Resources/SPPEditorScript.asset";

    [MenuItem("Window/SecurePlayerPrefs")]
    public static void init()
    {
        SPPSettings window = (SPPSettings)GetWindow(typeof(SPPSettings));
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
        MyScript.Password = EditorGUILayout.TextField("Password", MyScript.Password);
        MyScript.EType = (SecurePlayerPrefs.EncryptionType)EditorGUILayout.EnumPopup("Encryption Type", MyScript.EType);
        MyScript.NoOfHashing = EditorGUILayout.IntField("# of hashing keys", MyScript.NoOfHashing);

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

        EditorGUILayout.HelpBox("Set Default\nPassword: a unique device id\nEncryption Type: AES\n# of hashing keys: 1", MessageType.Info);
    }

    void SaveAsset()
    {
        EditorUtility.SetDirty(MyScript);
        AssetDatabase.SaveAssets();
    }

}
