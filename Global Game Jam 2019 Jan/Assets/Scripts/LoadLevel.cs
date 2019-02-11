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

    public GameObject[] canvases = new GameObject[5];

    private void Start()
    {
        canvases[0] = menu;
        canvases[1] = game;
        canvases[2] = endWin;
        canvases[3] = endLose;
        canvases[4] = credits;

        if (isOperator)
        {
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
    }

    public void LoadCanvas()
    {
        if (canvasToLoad == "menu")
        {
            canvases[0].SetActive(true);
            canvases[1].SetActive(false);
            canvases[2].SetActive(false);
            canvases[3].SetActive(false);
            canvases[4].SetActive(false);
        }

        else if (canvasToLoad == "game")
        {
            canvases[0].SetActive(false);
            canvases[1].SetActive(true);
            canvases[2].SetActive(false);
            canvases[3].SetActive(false);
            canvases[4].SetActive(false);
        }

        else if (canvasToLoad == "endWin")
        {
            canvases[0].SetActive(false);
            canvases[1].SetActive(false);
            canvases[2].SetActive(true);
            canvases[3].SetActive(false);
            canvases[4].SetActive(false);
        }

        else if (canvasToLoad == "endLose")
        {
            canvases[0].SetActive(false);
            canvases[1].SetActive(false);
            canvases[2].SetActive(false);
            canvases[3].SetActive(true);
            canvases[4].SetActive(false);
        }

        else if (canvasToLoad == "credits")
        {
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
