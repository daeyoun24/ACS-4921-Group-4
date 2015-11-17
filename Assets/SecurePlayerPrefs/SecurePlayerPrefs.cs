using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class SecurePlayerPrefs
{
    public static void SetString(string key, string value, string password)
    {
        var desEncryption = new DESEncryption();
        string hashedKey = GenerateMD5(key);
        string encryptedValue = desEncryption.Encrypt(value, password);
        PlayerPrefs.SetString(hashedKey, encryptedValue);
    }

    public static string GetString(string key, string password)
    {
        string hashedKey = GenerateMD5(key);
        if (PlayerPrefs.HasKey(hashedKey))
        {
            var desEncryption = new DESEncryption();
            string encryptedValue = PlayerPrefs.GetString(hashedKey);
            string decryptedValue;
            desEncryption.TryDecrypt(encryptedValue, password, out decryptedValue);
            return decryptedValue;
        }
        else
        {
            return "";
        }
    }

    public static void SetInt(string key, int value, string password)
    {
        var desEncryption = new DESEncryption();
        string hashedKey = GenerateMD5(key);
        string encryptedValue = desEncryption.Encrypt(value.ToString(), password);
        PlayerPrefs.SetString(hashedKey, encryptedValue);
    }

    public static int GetInt(string key, string password)
    {
        string hashedKey = GenerateMD5(key);
        if (PlayerPrefs.HasKey(hashedKey))
        {
            int decryptedInt = 0;
            var desEncryption = new DESEncryption();
            string encryptedValue = PlayerPrefs.GetString(hashedKey);
            string decryptedValue;
            desEncryption.TryDecrypt(encryptedValue, password, out decryptedValue);
            Int32.TryParse(decryptedValue, out decryptedInt);
            return decryptedInt;
        }
        else
        {
            return 0;
        }
    }

    public static void SetFloat(string key, float value, string password)
    {
        var desEncryption = new DESEncryption();
        string hashedKey = GenerateMD5(key);
        string encryptedValue = desEncryption.Encrypt(value.ToString(), password);
        PlayerPrefs.SetString(hashedKey, encryptedValue);
    }

    public static float GetFloat(string key, string password)
    {
        string hashedKey = GenerateMD5(key);
        if (PlayerPrefs.HasKey(hashedKey))
        {
            int decryptedFloat = 0;
            var desEncryption = new DESEncryption();
            string encryptedValue = PlayerPrefs.GetString(hashedKey);
            string decryptedValue;
            desEncryption.TryDecrypt(encryptedValue, password, out decryptedValue);
            Int32.TryParse(decryptedValue, out decryptedFloat);
            return decryptedFloat;
        }
        else
        {
            return 0;
        }
    }

    public static string GetString(string key, string defaultValue, string password)
    {
        if (HasKey(key))
        {
            return GetString(key, password);
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
