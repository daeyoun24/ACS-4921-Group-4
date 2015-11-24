using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    public Text SetInt1, SetFloat1, SetString1, GetInt1, GetFloat1, GetString1;
    public Text SetInt2, SetFloat2, SetString2, GetInt2, GetFloat2, GetString2;
    public Text SetInt3, SetFloat3, SetString3, GetInt3, GetFloat3, GetString3;

    void Start()
    {
        Test();
    }

    public void Test()
    {
        SecurePlayerPrefs.encryption = SecurePlayerPrefs.EncryptionType.DES;
        Display(SetInt1, SetFloat1, SetString1, GetInt1, GetFloat1, GetString1);

        SecurePlayerPrefs.encryption = SecurePlayerPrefs.EncryptionType.AES;
        Display(SetInt2, SetFloat2, SetString2, GetInt2, GetFloat2, GetString2);

        SecurePlayerPrefs.encryption = SecurePlayerPrefs.EncryptionType.AES32;
        Display(SetInt3, SetFloat3, SetString3, GetInt3, GetFloat3, GetString3);
    }

    void Display(Text SetInt, Text SetFloat, Text SetString, Text GetInt, Text GetFloat, Text GetString)
    {
        SecurePlayerPrefs.SetInt("setint", 7);
        SetInt.text = "7";
        GetInt.text = SecurePlayerPrefs.GetEncrytedString("setint");

        SecurePlayerPrefs.SetFloat("setfloat", 7.777f);
        SetFloat.text = "7.777";
        GetFloat.text = SecurePlayerPrefs.GetEncrytedString("setfloat");

        SecurePlayerPrefs.SetString("setstring", "string");
        SetString.text = "string";
        GetString.text = SecurePlayerPrefs.GetEncrytedString("setstring");
    }
    
}
