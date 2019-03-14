using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Spawner : MonoBehaviour
{
    public GameObject[] spawnedItems;
    public GameObject spawnerRef;
    public GameObject itemsRefTest;

    public Player playerRef;
    private bool canSpawn;
    //float xPosition  = 0;
    Vector3 newPosition;
    void start()
    {
        newPosition = itemsRefTest.transform.position;
    }

    //Multiple times a frame...
    void FixedUpdate()
    {
        // ...if the player is NOT in the house and canSpawn is true...
        if (playerRef.safeZone == false && canSpawn == true)
        {
            // ...begin Spawn function...
            Spawn();
            print("tiles");
            //
         
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

    //When function is called...
    void Spawn()
    {
        newPosition.x += 22.5f;
        newPosition.y = -4.517f;
        // ...if the player is not in the house...
        if (playerRef.safeZone == false)
        {
            
            // ...create an item from the spawnedItems Array at spawner's location, with spawner's quaternion...
            
            
            // ...and run the function again after the publicly set spawnDelay.

            for (int i = 0; i <50; i++) 
            {
                Instantiate(spawnedItems[Random.Range(0, spawnedItems.GetLength(0))], newPosition, Quaternion.identity);
                newPosition.x +=9.0f;

            }
        }


    }
}
