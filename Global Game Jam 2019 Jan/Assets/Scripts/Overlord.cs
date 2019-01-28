using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Overlord : MonoBehaviour
{
    #region Variables
    //Referenced
    public float score;
    public Text displayScore;
    public Player playerRef;
    public GameObject houseSpawnerRef;
    public Spawner SpawnerRef;

    //Move Detection
    private Vector3 previousPosition;
    private Vector3 currentPosition;
    private int framesStopped = 0;
    private float playerXPrevious;
    private float playerXCurrent;

    //Player reference
    public GameObject cameraRefTest;
    public GameObject itemsRefTest;
    #endregion

    //Index for spawn list
    int b = 0;

    //List length
    int listLength;

    //Array with game objects 
    public GameObject[] obj;


    //Once a frame...
    private void Update()
    {
        // ...as long as the player isn't in a safe zone...
        if (playerRef.safeZone == false)
        {
            // ...increase score in accordance with the difference in time between frames...
            score += Time.deltaTime;
            displayScore.text = "Score: " + ((int)(score*(100))).ToString();
        }

        #region Hotkeys
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
        #endregion

        #region Move Detection
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
        #endregion

        //sets variable to list length
        listLength = SpawnerRef.collectiblesList.Count;

        //If index goes out of range sets it to 0
        if (b >= (listLength - 1))
        {
            b = 0;
        }

        if(playerRef.collectiblesCollected >= 20)
        {
            SceneManager.LoadScene("Game_Over_Win");
        }
    }

    //When function is called...
    public void CheckItem()
    {
        // ...check list until the end of it...
        for (int i = 0; i < obj.Length; i++)
        {
            // ...go through every element...
            b = i;

            // ...and if the name matches...
            if (playerRef.itemName.Contains(obj[i].name))
            {
                // ...set the item to active...
                obj[i].gameObject.SetActive(true);

                // ...then, empty the list element to prevent respawns.
                SpawnerRef.collectiblesList[b] = null;
            }

            else
            {
                b = i;
            }
        }
    }

    #region Hotkey Functionality
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
    #endregion
}
