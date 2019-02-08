using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Spawner : MonoBehaviour
{
    public GameObject[] spawnedItems;
    public GameObject spawnerRef;
    public float spawnDelay;
    public float delayTimer;
    public Player playerRef;
    private bool canSpawn;
    //float xPosition  = 0;
    Vector3 newPosition;
    void start()
    {
        
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
    }

    //When function is called...
    void Spawn()
    {
        newPosition = new Vector3(22.5f,-4.517f,0);
        // ...if the player is not in the house...
        if (playerRef.safeZone == false)
        {
            // ...create an item from the spawnedItems Array at spawner's location, with spawner's quaternion...
            //Instantiate(spawnedItems[Random.Range(0, spawnedItems.GetLength(0))], newPosition, Quaternion.identity);

            // ...and run the function again after the publicly set spawnDelay.
            //Invoke("Spawn", spawnDelay);
            for (int i = 0; i <21; i++) 
            {
                
                Instantiate(spawnedItems[Random.Range(0, spawnedItems.GetLength(0))], newPosition, Quaternion.identity);
                newPosition.x +=9.0f;
                //transform.position = newPosition;
                print(newPosition);
            }
        }

    }
}
