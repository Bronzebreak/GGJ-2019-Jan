using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    //Variables
    public GameObject Menu;
    public GameObject Game;
    public GameObject End_Win;
    public GameObject End_Lose;
    public GameObject Credits;
    public string canvasToLoad;

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

    public void LoadCanvas()
    {
        if(canvasToLoad == "Menu")
        {
            Menu.SetActive(true);
            Game.SetActive(false);
            End_Win.SetActive(false);
            End_Lose.SetActive(false);
            Credits.SetActive(false);
        }

        if (canvasToLoad == "Game")
        {
            Menu.SetActive(false);
            Game.SetActive(true);
            End_Win.SetActive(false);
            End_Lose.SetActive(false);
            Credits.SetActive(false);
        }

        if (canvasToLoad == "End_Win")
        {
            Menu.SetActive(false);
            Game.SetActive(false);
            End_Win.SetActive(true);
            End_Lose.SetActive(false);
            Credits.SetActive(false);
        }

        if (canvasToLoad == "End_Lose")
        {
            Menu.SetActive(false);
            Game.SetActive(false);
            End_Win.SetActive(false);
            End_Lose.SetActive(true);
            Credits.SetActive(false);
        }

        else if (canvasToLoad == "Credits")
        {
            Menu.SetActive(false);
            Game.SetActive(false);
            End_Win.SetActive(false);
            End_Lose.SetActive(false);
            Credits.SetActive(true);
        }
        /*
        foreach (GameObject canvas in canvases)
        {
            if(canvas.name == canvasToLoad)
            {
                canvas.gameObject.SetActive(true);
            }

            else
            {
                canvas.gameObject.SetActive(false);
            }
        }
        */
        //SceneManager.LoadScene(levelToLoad);
    }

    //When function is called...
    public void RestartGame()
    {
        // ...load scene of publicly set name 'scene'.
        SceneManager.LoadScene("Game");
    }

    //When function is called...
    public void QuitGame()
    {
        // ...exit application.
        Application.Quit();
    }
}
