using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour
{
    private const string UNLOCK_KEY = "game_unlocked";
    private const string UNLOCK_SECURE_KEY = "game_unlocked";
    private const string SECURE_INT = "int";
    private const string SECURE_FLOAT = "float";
    
    public static void UnlockGame()
    {
        Debug.Log(SecurePlayerPrefs.password);
        PlayerPrefs.SetString(UNLOCK_KEY, "unlocked");
        SecurePlayerPrefs.SetString(UNLOCK_SECURE_KEY, "unlocked");
        SecurePlayerPrefs.SetInt(SECURE_INT, 7);
        Debug.Log("Get Int: " + SecurePlayerPrefs.GetInt(SECURE_INT));
        SecurePlayerPrefs.SetFloat(SECURE_FLOAT, 1.2345f);
        Debug.Log("Get Float: " + SecurePlayerPrefs.GetFloat(SECURE_FLOAT));       
    }

    public static void LockGame()
    {
        Debug.Log(SecurePlayerPrefs.password);
        PlayerPrefs.SetString(UNLOCK_KEY, "locked");
        SecurePlayerPrefs.SetString(UNLOCK_SECURE_KEY, "locked");
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

        if (SecurePlayerPrefs.GetString(UNLOCK_SECURE_KEY) == "unlocked")
        {
            return true;
        }
        else
        {
            return false;
        }        
    }

}
