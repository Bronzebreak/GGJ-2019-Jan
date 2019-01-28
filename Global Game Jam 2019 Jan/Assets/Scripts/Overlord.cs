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
    public GameObject houseSpawnerRef;
    public Spawner SpawnerRef;

    public Vector3 previousPosition;
    public Vector3 currentPosition;
    public bool playerStopped = false;
    public int framesStopped = 0;

    //Player reference
    public GameObject cameraRefTest;
    public GameObject itemsRefTest;

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

        //sets varieable to list length
        listLength = SpawnerRef.collectiblesList.Count;

        //If index goes out of range sets it to 0
        if (b >= (listLength - 1))
        {
            b = 0;
        }
    }

    public void CheckItem()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            //goes through all elements of the array and list.
            b = i;
            if (playerRef.itemName.Contains(obj[i].name))
            {
                //If object is in the array set it active
                obj[i].gameObject.SetActive(true);

                //Empties the list element so it doesnt spawn again
                SpawnerRef.collectiblesList[b] = null;
            }
            else
            {
                b = i;
            }
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
