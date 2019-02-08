using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    //Variables
    public string levelToLoad;

    //Once a frame...
    private void Update()
    {
        // ...if R is pressed...
        if (Input.GetKeyDown(KeyCode.R))
        {
            // ...execute restarting function.
            RestartGame();
        }
    }

    public void LoadingLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    //When function is called...
    public void RestartGame()
    {
        // ...load scene of publicly set name 'scene'.
        SceneManager.LoadScene("Menu");
    }

    //When function is called...
    public void QuitGame()
    {
        // ...exit application.
        Application.Quit();
    }
}
