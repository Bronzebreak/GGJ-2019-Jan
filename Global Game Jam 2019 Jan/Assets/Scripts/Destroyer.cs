using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{  
    //If collision with a trigger occurs...
    public void OnTriggerEnter2D(Collider2D other)
    {
        // ...if it's the player...
        if (other.tag == "Player")
        {
            // ...load the 'game over' scene.
            SceneManager.LoadScene("End");
            return;
        }

        // ...if it has a parent...
        else if (other.gameObject.transform.parent)
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
