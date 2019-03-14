using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Variables
    public GameObject homePosition;
    public Overlord overlordRef;
    Vector3 targetPosition = Vector3.zero;
    #endregion

    //Upon initialization...
    private void Start()
    {
        // ...set my position to my home location.
        targetPosition = homePosition.transform.position;
    }

    //Upon collision with a trigger...
    void OnTriggerEnter2D(Collider2D col)
    {
        // ...if I collide with the player...
        if (col.tag == "Player")
        {
            // ...run coroutine.
            StartCoroutine(SpawnCollectible());
        }
    }

    //When coroutine is run...
    IEnumerator SpawnCollectible()
    { 
        // ...begin Spawn function...
        Spawn();

        // ...then, set me to inactive...
        gameObject.SetActive(false);
        
        // ...then, end coroutine.
        yield break;
    }

    //When function is called...
    void Spawn()
    {
        // ...create a local variable...
        GameObject Item;

        // ...increase the x value of my target position and reset the y position...
        targetPosition.x +=25.0f;
        targetPosition.y = 0;

        // ...create an item from the collectibles list at my target position and quaternion identity...
        Item = Instantiate(overlordRef.collectiblesList[Random.Range(0, overlordRef.collectiblesList.Count)], targetPosition, Quaternion.identity);

        // ...set the object to active...
        Item.gameObject.SetActive(true);

        // ...then, return me to my home position.
        targetPosition = homePosition.transform.position;
    }
}
