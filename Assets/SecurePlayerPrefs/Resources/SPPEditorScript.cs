using UnityEngine;
using System.Collections;

[System.Serializable]
public class SPPEditorScript : ScriptableObject
{
    public string Password = SystemInfo.deviceUniqueIdentifier;
    public SecurePlayerPrefs.EncryptionType EType = SecurePlayerPrefs.EncryptionType.AES;
    public int NoOfHashing = 1;
        
    public void SetDefault()
    {
        Password = SystemInfo.deviceUniqueIdentifier;
        EType = SecurePlayerPrefs.EncryptionType.AES;
        NoOfHashing = 1;

        Save();
    }

    public void Save()
    {
        SecurePlayerPrefs.Password = Password;
        SecurePlayerPrefs.EType = EType;
        SecurePlayerPrefs.NoOfHashing = NoOfHashing;
    }
}
