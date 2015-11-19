using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour
{
    private const string UNLOCK_KEY = "game_unlocked";
    private const string UNLOCK_DES_KEY = "game_unlocked_DES";
    private const string UNLOCK_AES_KEY = "game_unlocked_AES";

    public static void UnlockGame()
    {
        PlayerPrefs.SetString(UNLOCK_KEY, "unlocked");
        SecurePlayerPrefs.SetInt(UNLOCK_DES_KEY, 7, "Password");
        Debug.Log("Get Int: " + SecurePlayerPrefs.GetInt(UNLOCK_DES_KEY, "Password"));
        SecurePlayerPrefs.SetFloat(UNLOCK_DES_KEY, 5, "Password");
        Debug.Log("Get Float: " + SecurePlayerPrefs.GetFloat(UNLOCK_DES_KEY, "Password"));
        SecurePlayerPrefs.SetString(UNLOCK_DES_KEY, "unlocked", "mykey");
    }

    public static void LockGame()
    {
        PlayerPrefs.SetString(UNLOCK_KEY, "locked");
        SecurePlayerPrefs.SetString(UNLOCK_DES_KEY, "locked", "mykey");
    }

    public static bool IsGameUnlocked()
    {
        //if (PlayerPrefs.GetString(UNLOCK_KEY) == "unlocked")
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}

        if (SecurePlayerPrefs.GetString(UNLOCK_DES_KEY, "mykey") == "unlocked")
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
