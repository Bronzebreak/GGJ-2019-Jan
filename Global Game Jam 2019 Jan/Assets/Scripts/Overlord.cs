using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Overlord : MonoBehaviour
{

    //Calculated current angle of building in relation to map/background. If it hits ~45* or -45*, gameOver should occur.
    public float angleRotation = 0.0f;
    public float timer;
    public float secondTimer;
    public string scene;
    bool tiltingRight;

    // Use this for initialization
    void Start ()
    {
		
	}

    //Once a frame...
    private void Update()
    {
        // ...count up time.
        secondTimer += Time.deltaTime;

        // ... then, if ~1s of time has surpassed...
        if (secondTimer >= 1)
        {
            // ...if tilting to the right...
            if (tiltingRight == true)
            {
                // ...time remaining is equal to the difference between 45 and the current rotation.
                timer = 45 - angleRotation;
            }

            // ...if tilting to the left...
            if (tiltingRight == false)
            {
                // ...time remaining is equal to the difference between -45 and the current rotation.
                timer = -45 + angleRotation;
            }

            // ...then print timer...
            print (timer);

            // ...then reset timer.
            secondTimer = 0;
        }
        
        
       

        

        

    }

    //Multiple times a frame...
    void FixedUpdate()
    {
        // ...if Esc is pressed...
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // ...execute 'Quit' function.
            QuitGame();
        }

        // ...if R is pressed...
        if (Input.GetKeyDown(KeyCode.R))
        {
            // ...execute 'RestartLevel' function.
            RestartGame();
        }
    }

    //When function is called...
    public void RestartGame()
    {
        // ...load scene of publicly set name 'scene'.
        SceneManager.LoadScene(scene);
    }

    //When function is called...
    public void QuitGame()
    {
        // ...exit application.
        Application.Quit();
    }
}
