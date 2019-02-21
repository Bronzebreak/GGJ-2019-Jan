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

    //public GameObject[] canvases = new GameObject[5];

    public GameObject itemsRefTest;
    
    Vector3 housePosition;

    //player death audio
    public AudioSource deathEffect;
    
    void Start() 
    {
        /*
        canvases[0] = menu;
        canvases[1] = game;
        canvases[2] = endWin;
        canvases[3] = endLose;
        canvases[4] = credits;
        */
    }

    //If collision with a trigger occurs...
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "House")
        {
            //itemsRefTest.transform.parent = houseSpawnerRef.transform;
            //itemsRefTest.transform.position = houseSpawnerRef.transform.position;
            housePosition.x += 486;
            housePosition.y = -3.11f;
            itemsRefTest.transform.position = housePosition;
        }
        
        // ...if it's the player...
        else if (other.tag == "Player")
        {
            levelReferencer.gameOverLose = true;
            /*
            // ...load the 'game over' scene.
            canvases[0].SetActive(false);
            canvases[1].SetActive(false);
            canvases[2].SetActive(false);
            canvases[3].SetActive(true);
            canvases[4].SetActive(false);
            */
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
