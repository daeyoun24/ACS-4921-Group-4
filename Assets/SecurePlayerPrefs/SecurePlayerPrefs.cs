using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System;

public static class SecurePlayerPrefs
{
    // Set true if you want to use AES.
    // false: use DES.
    public static bool useAES = true;

    // how many hashes do the getters and setters use to find values?
    public static uint bounce = 2;

    private static string passKey = GenerateMD5(SystemInfo.deviceUniqueIdentifier); 

    /**
     * Return:
     * 0: FAIL STATE
     * 1: PASSWORD FOUND/VERIFIED
     * 2: PASSWORD CREATED
     * 
     * Should be called every time the program executes.
     */
    public static int Initialize()
    {
        /** The following may corrupt saves and create data loss under the following conditions:
         * iOS7: If UIDevice identifierForVendor fails, ASIdentifierManager advertisingIdentifier is called, which may cause loss of save data due to new password.
         * Windows Store: uses AdvertisingManager::AdvertisingId, which can be disabled at any time and changes to fallback: HardwareIdentification::GetPackageSpecificToken().Id
         */
        string password = SystemInfo.deviceUniqueIdentifier;
        if (!HasKey(password)) {
            string verify = HashLoop((int)bounce, password);
            SetString(password, verify);
            return 2;
        }
        else {
            string verify = GetString(password);
            string check = HashLoop((int)bounce, password);
            if (verify.Equals(check)) { return 1; } else { return 0; }
        }
    }

    private static string HashLoop(int count, string hash)
    {
        if (count > 0)
        {
            string newHash = GenerateMD5(hash);
            newHash = HashLoop(count--, newHash);
            return newHash;
        }
        else
        {
            return hash;
        }
    }
    
    public static void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    public static void DeleteKey(string key)
    {
        string hashedKey = GenerateMD5(key);
        PlayerPrefs.DeleteKey(hashedKey);
    }

    public static float GetFloat(string key)
    {
        return GetFloat(key, 0.0f);
    }

    public static float GetFloat(string key, float defaultValue, bool isDecrypt = true)
    {
        float returnValue = defaultValue;
        string strValue = GetString(key);

        if (float.TryParse(strValue, out returnValue))
        {
            return returnValue;
        }
        else
        {
            return defaultValue;
        }
    }

    public static int GetInt(string key)
    {
        return GetInt(key, 0);
    }

    public static int GetInt(string key, int defaultValue, bool isDecrypt = true)
    {
        int returnValue = defaultValue;
        string strValue = GetString(key);

        if (int.TryParse(strValue, out returnValue))
        {
            return returnValue;
        }
        else
        {
            return defaultValue;
        }
    }

    public static string GetString(string key)
    {
        return GetString(key, "");
    }

    public static string GetString(string key, string defaultValue)
    {
        Encryption encryption = new Encryption();
        string realKey = HashLoop((int)bounce, key);
        if (HasKey(realKey))
        {
            string hashedKey = GenerateMD5(HashLoop((int)bounce, key));
            string encryptedValue = PlayerPrefs.GetString(hashedKey);
            string decryptedValue;
            encryption.TryDecrypt(encryptedValue, passKey, out decryptedValue);
            return decryptedValue;
        }
        else
        {
            return defaultValue;
        }
    }

    public static bool HasKey(string key)
    {
        string hashedKey = GenerateMD5(key);
        bool hasKey = PlayerPrefs.HasKey(hashedKey);
        return hasKey;
    }

    public static void Save()
    {
        PlayerPrefs.Save();
    }

    public static void SetFloat(string key, float value)
    {
        SetString(key, value.ToString());
    }

    public static void SetInt(string key, int value)
    {
        SetString(key, value.ToString());
    }

    public static void SetString(string key, string value)
    {
        Encryption encryption = new Encryption();

        string hashedKey = GenerateMD5(HashLoop((int)bounce, key));
        string encryptedValue = encryption.Encrypt(value, passKey);
        PlayerPrefs.SetString(hashedKey, encryptedValue);
    }

    /// <summary>
    /// Generates an MD5 hash of the given text.
    /// WARNING. Not safe for storing passwords
    /// </summary>
    /// <returns>MD5 Hashed string</returns>
    /// <param name="text">The text to hash</param>
    static string GenerateMD5(string text)
    {
        var md5 = MD5.Create();
        byte[] inputBytes = Encoding.UTF8.GetBytes(text);
        byte[] hash = md5.ComputeHash(inputBytes);

        // step 2, convert byte array to hex string
        var sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString();
    }
}
