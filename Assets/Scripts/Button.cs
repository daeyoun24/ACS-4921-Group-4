using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    Text _buttonText;

    void Start()
    {
        _buttonText = transform.GetComponentInChildren<Text>();

        if (PlayerPrefsManager.IsGameUnlocked())
        {
            _buttonText.text = "Lock";
        }
    }

    public void Unlock()
    {
        if (!PlayerPrefsManager.IsGameUnlocked())
        {
            PlayerPrefsManager.UnlockGame();
            _buttonText.text = "Lock";
        }        
        else
        {
            PlayerPrefsManager.LockGame();
            _buttonText.text = "Unlock";
        }
    }
}
