using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Spawner : MonoBehaviour
{
    #region Variables
    //Script References
    public Player playerRef;

    //Spawn Functionality Variables
    public GameObject[] spawnedItems;
    public GameObject spawnerRef;
    public GameObject homeChunk;
    private bool canSpawn;
    Vector3 targetPosition;
    #endregion

    //Upon game start...
    void Start()
    {
        // ...target location is the home chunk's position.
        targetPosition = homeChunk.transform.position;
    }

    //Multiple times a frame...
    void FixedUpdate()
    {
        // ...if the player is NOT in the house and canSpawn is true...
        if (playerRef.safeZone == false && canSpawn == true)
        {
            // ...begin Spawn function...
            Spawn();
         
            // ...and disallow further spawn calls.
            canSpawn = false;
        }

        // ...if the player IS in the house...
        else if (playerRef.safeZone == true)
        {
            // ...spawn can be called.
            canSpawn = true;
        }

        // ...then, update target position to home's new position.
        targetPosition = homeChunk.transform.position;
    }

    //When function is called...
    void Spawn()
    {
        // ...update and set target position...
        targetPosition.x += 22.5f;
        targetPosition.y = -4.517f;

        // ...then, if the player is not in the house...
        if (playerRef.safeZone == false)
        {
            // ...50 times...
            for (int i = 0; i <50; i++) 
            {
                // ...instantiate a random item from the list at target position with my quaternion identity...
                Instantiate(spawnedItems[Random.Range(0, spawnedItems.GetLength(0))], targetPosition, Quaternion.identity);

                // ...then increase location of next spawn by 9 units.
                targetPosition.x +=9.0f;
            }
        }
    }
}
