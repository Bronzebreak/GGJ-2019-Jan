using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Overlord : MonoBehaviour
{
    #region Variables
    //Collectibles
    //playerRef.collectiblesCollected (int);
    public Text winCollectibles;
    public Text loseCollectibles;

    //Score
    public float score;
    public bool freezeScore;
    public Text displayScore;
    public Text winScore;
    public Text loseScore;

    //Time
    public float timeMinutes;
    public float timeSeconds;
    public Text timeText;
    public Text winTimeText;
    public Text loseTimeText;

    public Text finalScoreText;

    //References
    public Player playerRef;
    public Spawner SpawnerRef;
    public LoadLevel levelReferencer;

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

    //player death audio
    public AudioSource deathEffect;

    public static GameObject refrence;

    //Once a frame...
    private void Update()
    {
        // ...if not in the gameOver states...
        if (levelReferencer.gameOverWin == false && levelReferencer.gameOverLose == false)
        {
            // ...count up the time based off the difference in time between frames.
            timeSeconds += Time.deltaTime;

            // ...then, if time is greater than or equal to 60...
            if (timeSeconds >= 60)
            {
                // ...add to the minute timer...
                timeMinutes++;

                // ...and reset the second timer.
                timeSeconds = 0;
            }

            // ...then, update the time text.
            timeText.text = "Time Taken \n" + ((int)timeMinutes).ToString() + "m " + ((int)timeSeconds).ToString() + "s";
        }

        // ...as long as the player isn't in a safe zone...
        if (playerRef.safeZone == false && freezeScore == false)
        {
            // ...increase score in accordance with the difference in time between frames...
            score += Time.deltaTime;

            // ...and then update the score text.
            displayScore.text = "Score: " + ((int)(score * (100))).ToString();
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

        if (Mathf.Abs(playerXPrevious - playerXCurrent) <= 0.005f)
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
            freezeScore = true;
        }

        else freezeScore = false;
        #endregion

        //sets variable to list length
        listLength = SpawnerRef.collectiblesList.Count;

        //If index goes out of range sets it to 0
        if (b >= (listLength - 1))
        {
            b = 0;
        }

        if (playerRef.collectiblesCollected >= 20)
        {
            levelReferencer.gameOverWin = true;
        }
    }

    //When function is called...
    public void CheckItem()
    {
        /*
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
                SpawnerRef.collectiblesList.RemoveAt(b);
            }

            else
            {
                b = i;
            }
        }

    */
        foreach(GameObject collectible in obj)
        {
            print("2");
            if (playerRef.itemName == collectible.name)
            {
                print("3");
                collectible.gameObject.SetActive(true);
            }
        }

    }

    #region Hotkey Functionality
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
    #endregion
}


