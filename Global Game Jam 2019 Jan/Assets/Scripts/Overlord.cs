using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Overlord : MonoBehaviour
{
    public float score;

    // Use this for initialization
    void Start ()
    {
		
	}

    //Once a frame...
    private void Update()
    {
        score += Time.deltaTime;
        print("Score: " + score);

        // ...if Esc is pressed...
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ...execute quitting function.
            QuitGame();
        }

        // ...if R is pressed...
        if (Input.GetKeyDown(KeyCode.R))
        {
            // ...execute restarting function.
            RestartGame();
        }
    }

    //When function is called...
    public void RestartGame()
    {
        // ...load scene of publicly set name 'scene'.
        SceneManager.LoadScene("Derek");
    }

    //When function is called...
    public void QuitGame()
    {
        // ...exit application.
        Application.Quit();
    }
}
