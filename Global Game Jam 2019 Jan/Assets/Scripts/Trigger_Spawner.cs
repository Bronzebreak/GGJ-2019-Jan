using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Spawner : MonoBehaviour 
{
	// reference to the trigger prefab
	public GameObject spawnedItems;
	// reference to the object that spawns 
    public GameObject itemsRefTest;
    public Player playerRef;
    private bool canSpawn;
    //float xPosition  = 0;
	Vector3 newPosition;

	// Use this for initialization
    void start()
    {
        newPosition = itemsRefTest.transform.position;
    }
	
	// Update is called once per frame
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
        newPosition = itemsRefTest.transform.position;
    }
	 void Spawn()
    {
        newPosition.x += 22.5f;
        newPosition.y = -3.517f;
        // ...if the player is not in the house...
        if (playerRef.safeZone == false)
        {
            // ...create an item from the spawnedItems Array at spawner's location, with spawner's quaternion...
            // ...and run the function again after the publicly set spawnDelay.ы
            for (int i = 0; i <5; i++) 
            {         
                Instantiate(spawnedItems, newPosition, Quaternion.identity);
                newPosition.x +=90.0f;
            }
        }
    }
}
