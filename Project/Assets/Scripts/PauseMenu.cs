using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    public static bool paused = false;

    private void Start()
    {
        paused = false;
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (paused)
                UnPause();
            else
                Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        paused = true;
        menu.SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        paused = false;
        menu.SetActive(false);
    }
}
