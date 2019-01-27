using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCamera : MonoBehaviour {
    public Transform player;

    //play music
  //  public AudioClip backSounds;
   // private AudioSource backEffect;

   // void Start()
   // {
   //     backEffect = GetComponent<AudioSource>();
   //     backEffect.clip = backSounds;
   // }
    //Once a frame...
    void Update()
    {
        // ...track player location, with constant y and z values.
        transform.position = new Vector3(player.position.x + 4f, 0, -10);

       // //play music
       // backEffect.Play();
    }
}
