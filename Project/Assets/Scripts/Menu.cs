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
        //starts startingscene
    }

    public void AdjustVolume(float val)
    {
        AudioListener.volume = val;
    }
}
