using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string nameOfSceneToLoad;

    public void ExitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    public void StartGame()
    {
        SceneManager.LoadScene(nameOfSceneToLoad);
        Time.timeScale = 1;
        //starts startingscene
    }

    public void LoadScene(string s)
    {
        SceneManager.LoadScene(s);
        Time.timeScale = 1;
    }

    public void AdjustVolume(float val)
    {
        AudioListener.volume = val;
    }
}
