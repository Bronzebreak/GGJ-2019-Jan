using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject itemRef;
    int pTouched;
    public Overlord overlordRef;
    //public Player playerRef;
    
    Vector3 newPosition;
    //Upon initialization...
    private void Start()
    {
        // ...run Spawn function after the publicly set spawnDelay.
        newPosition = itemRef.transform.position;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            StartCoroutine(SpawnCollectible());
        }
    }
    IEnumerator SpawnCollectible()
    { 
            Spawn();
            gameObject.SetActive(false);
            print("spawn");   
            yield break;
    }
    //When function is called...
    void Spawn()
    {
        // ...as long as player is not in the House...
            GameObject Item;
            newPosition.x +=25.0f;
            newPosition.y = 0;
            // ...create an item from the spawnedItems Array at spawner's location, with spawner's quaternion...
            Item = Instantiate(overlordRef.collectiblesList[Random.Range(0, overlordRef.collectiblesList.Count)], newPosition, Quaternion.identity);
            Item.gameObject.SetActive(true);
            newPosition = itemRef.transform.position;
    }
}
