using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Overlord : MonoBehaviour
{
    public float score;
    public Player playerRef;
    public float playerXPrevious;
    public float playerXCurrent;
    public Text displayScore;

    public Vector3 previousPosition;
    public Vector3 currentPosition;
    public bool playerStopped = false;
    public int framesStopped = 0;

    //Once a frame...
    private void Update()
    {
        // ...as long as the player isn't in a safe zone...
        if (playerRef.safeZone == false)
        {
            // ...increase score in accordance with the difference in time between frames...
            score += Time.deltaTime;
            displayScore.text = score.ToString();
        }

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

        playerXPrevious = playerXCurrent;
        playerXCurrent = playerRef.transform.position.x;

        if (Mathf.Abs(playerXPrevious-playerXCurrent) <= 0.005f)
        {
            //playerStopped = true;
            framesStopped += 1;
            
        }

        else
        {
            //playerStopped = false;
            framesStopped = 0;
        }

        if (framesStopped >= 2 && playerRef.safeZone == false)
        {
            SceneManager.LoadScene("End");
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
