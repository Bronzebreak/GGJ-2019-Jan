using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
    public LoadLevel levelReferencer;
    public string canvasToLoad;
    public GameObject menu;
    public GameObject game;
    public GameObject endWin;
    public GameObject endLose;
    public GameObject credits;

    public GameObject itemsRefTest;
    
    Vector3 housePosition;

    //player death audio
    public AudioSource deathEffect;
    
    void Start() 
    {

    }

    //If collision with a trigger occurs...
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "House")
        {
            housePosition.x += 486;
            housePosition.y = -3.11f;
            itemsRefTest.transform.position = housePosition;
        }
        
        // ...if it's the player...
        else if (other.tag == "Player")
        {
            levelReferencer.gameOverLose = true;

        }
        
        // ...if it has a parent...
        else if (other.gameObject.transform.parent != null)
        {
            // ...destroy the parent (and all children).
            Destroy(other.gameObject.transform.parent.gameObject);
        }

        // ...if it doesn't have a parent...
        else
        {
            // ...destroy the object.
            Destroy(other.gameObject);
        }
    }
}
