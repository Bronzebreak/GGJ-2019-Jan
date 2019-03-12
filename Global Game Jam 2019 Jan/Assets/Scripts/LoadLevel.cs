using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    //Variables
    public string canvasToLoad;
    public GameObject menu;
    public GameObject game;
    public GameObject endWin;
    public GameObject endLose;
    public GameObject credits;
    public bool isOperator = false;
    public bool gameOverLose = false;
    public bool gameOverWin = false;
    private bool gameEnded = false;

    public GameObject[] canvases = new GameObject[5];

    //Upon game start...
    private void Start()
    {
        // ...set the publicly set canvases...
        canvases[0] = menu;
        canvases[1] = game;
        canvases[2] = endWin;
        canvases[3] = endLose;
        canvases[4] = credits;

        // ...and if this object is the game manager...
        if (isOperator)
        {
            // ...it sets the menu screen to true.
            canvases[0].SetActive(true);
            canvases[1].SetActive(false);
            canvases[2].SetActive(false);
            canvases[3].SetActive(false);
            canvases[4].SetActive(false);
        }
    }

    //Once a frame...
    private void Update()
    {
        // ...if R is pressed...
        if (Input.GetKeyDown(KeyCode.R))
        {
            // ...execute restarting function.
            RestartGame();
        }

        // ...if the game state has been lost for the first time...
        if (gameOverLose && !gameEnded)
        {
            // ...end the game to prevent recurrence, and set the lose game over screen to true.
            gameEnded = true;
            canvases[0].SetActive(false);
            canvases[1].SetActive(false);
            canvases[2].SetActive(false);
            canvases[3].SetActive(true);
            canvases[4].SetActive(false);
        }

        // ...if the game state has been won for the first time...
        if (gameOverWin && !gameEnded)
        {
            // ...end the game to prevent recurrence, and set the win game over screen to true.
            gameEnded = true;
            canvases[0].SetActive(false);
            canvases[1].SetActive(false);
            canvases[2].SetActive(true);
            canvases[3].SetActive(false);
            canvases[4].SetActive(false);
        }
    }

    //When function is called...
    public void LoadCanvas()
    {
        // ...if the canvas to be loaded is 'menu'...
        if (canvasToLoad == "menu")
        {
            // ...display the menu screen.
            canvases[0].SetActive(true);
            canvases[1].SetActive(false);
            canvases[2].SetActive(false);
            canvases[3].SetActive(false);
            canvases[4].SetActive(false);
        }

        // ...if the canvas to be loaded is 'game'...
        else if (canvasToLoad == "game")
        {
            // ...display the game scene.
            canvases[0].SetActive(false);
            canvases[1].SetActive(true);
            canvases[2].SetActive(false);
            canvases[3].SetActive(false);
            canvases[4].SetActive(false);
        }

        //...if the canvas to be loaded is 'credits'...
        else if (canvasToLoad == "credits")
        {
            // ...display the credits scene.
            canvases[0].SetActive(false);
            canvases[1].SetActive(false);
            canvases[2].SetActive(false);
            canvases[3].SetActive(false);
            canvases[4].SetActive(true);
        }
    }

    //When function is called...
    public void RestartGame()
    {
        // ...load scene of publicly set name 'scene'.
        SceneManager.LoadScene("Test");
    }

    //When function is called...
    public void QuitGame()
    {
        // ...exit application.
        Application.Quit();
    }
}
