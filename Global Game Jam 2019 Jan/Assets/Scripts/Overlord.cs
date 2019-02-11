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
    public float time;
    public bool freezeScore;
    public Player playerRef;
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

    //text refernce
    public Text displayScore;
    public Text timeText;
    public Text playerFinalscoreText;

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
        // ...count up the time based off the difference in time between frames.
        time += Time.deltaTime;

        // ...as long as the player isn't in a safe zone...
        if (playerRef.safeZone == false && freezeScore == false)
        {
            // ...increase score in accordance with the difference in time between frames...
            score += Time.deltaTime;

            // ...and then update the score text.
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

    //public void display()
    //{
        //player text update
       // if (SceneManager.GetActiveScene().name == ("Game_Over_Lose"))
           // {
               // displayScore = GameObject.Find("score").GetComponent<Text>();

           // score = SetFloat.Find("score");

            //score.GetComponent<Text>().text = "score" + theScore;
           // }
    //}
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
    
  /*  private void Awake()
    {
        DontDestroyOnLoad(displayScore);
         {
            refrence = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
         }

         else if (refrence != this)

         {
            Destroy(this.gameObject);
         }

    }
    */
    
}


