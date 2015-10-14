using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour
{
    private const string UNLOCK_KEY = "game_unlocked";
    private const string UNLOCK_SECURED_KEY = "game_unlocked_test";

    public static void UnlockGame()
    {
        PlayerPrefs.SetString(UNLOCK_KEY, "unlocked");
        SecurePlayerPrefs.SetString(UNLOCK_SECURED_KEY, "unlocked", "mykey");
    }

    public static void LockGame()
    {
        PlayerPrefs.SetString(UNLOCK_KEY, "locked");
        SecurePlayerPrefs.SetString(UNLOCK_SECURED_KEY, "locked", "mykey");
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

        if (SecurePlayerPrefs.GetString(UNLOCK_SECURED_KEY, "mykey") == "unlocked")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
