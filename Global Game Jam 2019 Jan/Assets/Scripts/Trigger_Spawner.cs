using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Spawner : MonoBehaviour 
{
    #region Variables
    //Script References
    public Player playerRef;

    //Spawn Functionality Variables
    public GameObject spawnedItems;
    public GameObject homeChunk;
    private bool canSpawn;
	Vector3 targetPosition;
    #endregion

    //Upon game start...
    void Start()
    {
        // ...set target to the home chunk's location.
        targetPosition = homeChunk.transform.position;
    }
	
	//Once a frame...
    void FixedUpdate()
    {
        // ...if the player is NOT in the house and I'm allowed to spawn...
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

        // ...then update my location to the home chunk's location.
        targetPosition = homeChunk.transform.position;
    }

    //When function is called...
	 void Spawn()
    {
        // ...increase and set new target position...
        targetPosition.x += 22.5f;
        targetPosition.y = -3.517f;

        // ...then, if the player is not in the house...
        if (playerRef.safeZone == false)
        {
            // ...and run the instantiation 5 times by...
            for (int i = 0; i <5; i++) 
            {         
                // ...creating an item from the spawnedItems array, at the target position with my quaternion identity...
                Instantiate(spawnedItems, targetPosition, Quaternion.identity);

                // ...and then increasing the target position's location 90 units to the right.
                targetPosition.x +=90.0f;
            }
        }
    }
}
