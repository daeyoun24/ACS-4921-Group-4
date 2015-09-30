using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour
{
    private const string UNLOCK_KEY = "game_unlocked";

    public static void UnlockGame()
    {
        PlayerPrefs.SetString(UNLOCK_KEY, "unlocked");
    }

    public static void LockGame()
    {
        PlayerPrefs.SetString(UNLOCK_KEY, "locked");
    }

    public static bool IsGameUnlocked()
    {
        if (PlayerPrefs.GetString(UNLOCK_KEY) == "unlocked")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
