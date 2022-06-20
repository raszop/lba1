using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSkipper : MonoBehaviour
{
    public float timeToLoadMainMenu = 3.0f;

    private void Start()
    {
        Invoke(nameof(LoadMainMenu), timeToLoadMainMenu);
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
