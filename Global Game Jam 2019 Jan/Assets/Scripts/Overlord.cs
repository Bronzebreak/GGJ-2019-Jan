using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Overlord : MonoBehaviour
{
    #region Variables
    #region Irrelevant
    //Collectibles
    //playerRef.collectiblesCollected (int);
    #endregion
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
    public string timeTaken;
    public Text winTime;
    public Text loseTime;

    //Final Score
    public string finalScore;
    public Text winFinalScore;
    public Text loseFinalScore;


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

    #region Irrelevant
    public List<GameObject> collectiblesList;
    //int b = 0;

    //List length
    //int listLength;
    #endregion

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

            // ...then, update the time texts.
            timeTaken = "Time Taken\n" + ((int)timeMinutes).ToString() + "m " + ((int)timeSeconds).ToString() + "s";
            winTime.text = timeTaken;
            loseTime.text = timeTaken;
        }

        // ...as long as the player isn't in a safe zone or stopped...
        if (playerRef.safeZone == false && freezeScore == false)
        {
            // ...increase score in accordance with the difference in time between frames...
            score += Time.deltaTime;

            // ...and then update the score texts.
            displayScore.text = "Score\n" + ((int)(score * (100))).ToString();
            loseScore.text = displayScore.text;
            winScore.text = displayScore.text;
        }
        
        // ...tally final score based off of score and time taken...
        finalScore = ((int)((score * (100)) - 30 * ((60 * timeMinutes) + (timeSeconds)))).ToString();

        // ...and then update final score texts...
        winFinalScore.text = "Final Score\n" + finalScore;
        loseFinalScore.text = "Final Score\n" + finalScore;

        // ...and then set the collectibles text dependent on items collected.
        winCollectibles.text = "You collected all of the items, and made it home!";
        loseCollectibles.text = "You collected " + playerRef.collectiblesCollected + "items and didn't make it home...";

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

        #region Irrelevant
        //sets variable to list length
        //listLength = SpawnerRef.collectiblesList.Count;


        //If index goes out of range sets it to 0
        /*
        if (b >= (listLength - 1))
        {
            b = 0;
        }
        */
        #endregion 

        // ...if player has collected all items...
        if (playerRef.collectiblesCollected >= 20)
        {
            // ...the game is over.
            levelReferencer.gameOverWin = true;
        }
    }

    //When function is called...
    public void CheckItem()
    {
        #region
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
        #endregion
        // ...for each collectible in the array...
        foreach (GameObject collectible in obj)
        {
            // ...if the name of the collided item matches a collectible name...
            if (playerRef.itemName == collectible.name)
            {
                // ...set that item to active (visible).
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


