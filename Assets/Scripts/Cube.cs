using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour
{
    Renderer _cubeRenderer;
    Color _initialColor;
    bool _isCubeGreen;

    // Use this for initialization
    void Start()
    {
        _cubeRenderer = GetComponent<MeshRenderer>();
        _initialColor = _cubeRenderer.material.color;

        if (PlayerPrefsManager.IsGameUnlocked())
        {
            TurnGreen();
        }
    }

    void Update()
    {
        if (PlayerPrefsManager.IsGameUnlocked() && _isCubeGreen == false)
        {
            TurnGreen();            
        }
        else if (!PlayerPrefsManager.IsGameUnlocked() && _isCubeGreen == true)
        {
            _cubeRenderer.material.color = _initialColor;
            _isCubeGreen = false;
        }
    }

    void TurnGreen()
    {
        _cubeRenderer.material.color = Color.green;
        _isCubeGreen = true;
    }
}
