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
    public GameObject[] canvases = new GameObject[5];
    public string canvasToLoad;

    private void Start()
    {
        canvases[0] = Menu;
        canvases[1] = Game;
        canvases[2] = End_Win;
        canvases[3] = End_Lose;
        canvases[4] = Credits;
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
