using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
    public GameObject houseSpawnerRef;
    public GameObject itemsRefTest;
    
    Vector3 housePosition;


    //player death audio
    public AudioSource deathEffect;
    


    void start() 
    {
        housePosition = itemsRefTest.transform.position;
        housePosition.y = -4.517f;
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
            
            print(housePosition);
        }

        // ...if it's the player...
        else if (other.tag == "Player")
        {
            // ...load the 'game over' scene.

            SceneManager.LoadScene("Game_Over_Lose");
            return;
            
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
