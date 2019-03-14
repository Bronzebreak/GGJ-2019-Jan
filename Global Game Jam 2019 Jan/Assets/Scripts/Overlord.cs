using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Overlord : MonoBehaviour
{
    #region Variables
    //UI References
    public Text winCollectibles;
    public Text loseCollectibles;
    public Text displayScore;
    public Text winScore;
    public Text loseScore;
    public Text winTime;
    public Text loseTime;
    public Text winFinalScore;
    public Text loseFinalScore;

    //Statistic Trackers
    public float score;
    public float timeMinutes;
    public float timeSeconds;
    public string timeTaken;
    public string finalScore;

    //Script References
    public Player playerRef;
    public LoadLevel levelReferencer;

    //Move Detection
    private Vector3 previousPosition;
    private Vector3 currentPosition;
    private int framesStopped = 0;
    private float playerXPrevious;
    private float playerXCurrent;
    public bool freezeScore;

    //Collectible References
    public List<GameObject> collectiblesList;
    public GameObject[] obj;

    //Audio
    public AudioSource deathEffect;
    #endregion

    //Once a frame...
    private void Update()
    {
        // ...if not in the gameOver states...
        if (levelReferencer.gameOverWin == false && levelReferencer.gameOverLose == false)
        {
            // ...count up the time based off the difference in time between frames...
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
        loseCollectibles.text = "You collected " + (20 - collectiblesList.Count) + " items and didn't make it home...";

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
        //Variables
        playerXPrevious = playerXCurrent;
        playerXCurrent = playerRef.transform.position.x;

        // ...if the player's location between frames is less than or equal to .005 units...
        if (Mathf.Abs(playerXPrevious - playerXCurrent) <= 0.005f)
        {
            // ...the player has stopped moving for one frame...
            framesStopped += 1;
        }

        // ...if the player's location between frames is greater than .005 units...
        else
        {
            // ...the player is moving.
            framesStopped = 0;
        }

        // ...if the player has stopped moving for more than two frames, and isn't in the safe zone...
        if (framesStopped >= 2 && playerRef.safeZone == false)
        {
            // ...the player is stationary, so freeze score.
            freezeScore = true;
        }

        // ...if the player doesn't stop moving, continue counting up score.
        else freezeScore = false;
        #endregion

        // ...if player has removed all items from the collectibles list via contact with that object in-game (IE, has collected all objects)...
        if (collectiblesList.Count == 0)
        {
            // ...the player has won the game.
            levelReferencer.gameOverWin = true;
        }
    }
    
    //When function is called...
    public void CheckItem()
    {
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
        SceneManager.LoadScene("Scene");
    }

    //When function is called...
    public void QuitGame()
    {
        // ...exit application.
        Application.Quit();
    }
    #endregion
}


