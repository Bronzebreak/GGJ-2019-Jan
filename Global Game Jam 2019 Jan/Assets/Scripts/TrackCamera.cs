using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCamera : MonoBehaviour {
    //Variables
    public Transform player;
    
    //Once a frame...
    void Update()
    {
        // ...update my position to four units to the right of and 10 units behind the player.
        transform.position = new Vector3(player.position.x + 4f, 0, -10);
    }
}
