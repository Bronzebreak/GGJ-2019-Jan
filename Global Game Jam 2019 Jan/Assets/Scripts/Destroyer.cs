using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
    #region Variables
    //Script References
    public LoadLevel levelReferencer;

    //Teleportation Functionality Variables
    public GameObject houseChunk;
    Vector3 housePositionMarker = new Vector3 (0, -3.11f);

    //Audio
    public AudioSource deathEffect;
    #endregion

    //Upon collision...
    public void OnTriggerEnter2D(Collider2D other)
    {
        // ...if the object is the house chunk...
        if (other.tag == "House Chunk")
        {
            // ...increase the x position of the house marker by 486...
            housePositionMarker.x += 486;

            // ...and move the house to the new location.
            houseChunk.transform.position = housePositionMarker;
        }
        
        // ...if it's the player...
        else if (other.tag == "Player")
        {
            // ...the game is over and the player loses.
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
