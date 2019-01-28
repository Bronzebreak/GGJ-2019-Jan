using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnDelay;
    public float delayTimer;
    public Player playerRef;
    public List<GameObject> collectiblesList;

    //Upon initialization...
    private void Start()
    {
        // ...run Spawn function after the publicly set spawnDelay.
        Invoke("Spawn", spawnDelay);
    }

    //When function is called...
    void Spawn()
    {
        // ...as long as player is not in the House...
        if (playerRef.safeZone == false)
        {
            GameObject Item;

            // ...create an item from the spawnedItems Array at spawner's location, with spawner's quaternion...
            Item = Instantiate(collectiblesList[Random.Range(0, 19)], transform.position, Quaternion.identity);
            Item.gameObject.SetActive(true);

            // ...and run the function again after the publicly set spawnDelay.
            Invoke("Spawn", spawnDelay);
        }

        // ...if player is in the House, run the function again after the publicly set spawnDelay.
        else Invoke("Spawn", spawnDelay);
    }
}
