using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnedItems;
    public float spawnMin = 1.0f;
    public float spawnMax = 3.0f;
    public Player playerRef;

    //Upon initialization...
    void Start()
    {
        // ...begin 'Spawn' function.
        Spawn();
    }
    
    void Spawn()
    {
        if (playerRef.safeZone == false)
        {
            Instantiate(spawnedItems[Random.Range(0, spawnedItems.GetLength(0))], transform.position, Quaternion.identity);
            Invoke("Spawn", Random.Range(spawnMin, spawnMax));
        }

        else
        {
            Invoke("Spawn", Random.Range(spawnMin, spawnMax));
        }
    }
}
