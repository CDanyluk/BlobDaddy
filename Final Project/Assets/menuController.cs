using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public void PlayGame()
    {
        // Add an index to your scene and you can go back and forward between scenes
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // File > Build Settings, to see indexes of scenes
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
