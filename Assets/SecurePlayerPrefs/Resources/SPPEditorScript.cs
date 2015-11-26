using UnityEngine;
using System.Collections;

[System.Serializable]
public class SPPEditorScript : ScriptableObject
{
    public string password = SystemInfo.deviceUniqueIdentifier;
    public SecurePlayerPrefs.EncryptionType encryption = SecurePlayerPrefs.EncryptionType.AES;
    public int bounce = 1;
        
    public void SetDefault()
    {
        password = SystemInfo.deviceUniqueIdentifier;
        encryption = SecurePlayerPrefs.EncryptionType.AES;
        bounce = 1;

        Save();
    }

    public void Save()
    {
        SecurePlayerPrefs.password = password;
        SecurePlayerPrefs.encryption = encryption;
        SecurePlayerPrefs.bounce = bounce;
    }
}
