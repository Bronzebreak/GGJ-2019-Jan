using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Variables
    //Externally Referenced Variables
    private Rigidbody2D rigBody;
    public Overlord overlordReference;
    public Spawner spawnReference;
    public string itemName;
    public int collectiblesCollected;

    //Action Variables
    public KeyCode moveRight;
    public KeyCode moveLeft;
    public string horizontalAxis;

    //Action Restrictions
    private bool canJump;
    public bool safeZone = false;

    //Sound
    public AudioSource jumpEffect;
    public AudioSource collectEffect;
    public AudioSource bGM;
    #endregion

    void Start()
    {
        //Retrieves the rigidbody component attached to this game object.
        rigBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        #region Jump
        //If player is allowed to jump...
        if (canJump == true && !safeZone)
        {
            // ...if player presses space... 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //...the character applies a force impulse to the vertical axis...
                rigBody.AddForce(new Vector2(0, 75f), ForceMode2D.Impulse);

                //... and the player can no longer jump.
                canJump = false;

                //play sound
                jumpEffect.Play();
            }
        }
        #endregion
    }

    //Multiple times a frame...
    void FixedUpdate()
    {
        #region Movement
        if (safeZone)
        {
            // ...retrieve the horizontal input axis value.
            float moveHori = Input.GetAxis(horizontalAxis);

            // ...then, move horizontally based on the horizontal input; do NOT affect vertical movement.
            rigBody.velocity = new Vector2(moveHori * 3.75f, rigBody.velocity.y);
        }

        else
        {
            rigBody.velocity = new Vector2(5, rigBody.velocity.y);
        }
        #endregion
    }

    //Upon staying overlapped with an object...
    private void OnTriggerStay2D(Collider2D collision)
    {
        // ...if object's name contains 'ground'
        if (collision.gameObject.name.ToLower().Contains("ground"))
        {
            // ...enable jumping.
            canJump = true;
        }
    }

    //Once you collide with a trigger...
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ...if it has 'home' in its name...
        if (collision.gameObject.name.ToLower().Contains("home"))
        {
            // ...player is in a safe zone...
            safeZone = true;
        }

        // ...if it is a collectible...
        if (collision.tag == "Collectible")
        {
            //sets variable value equal to object name
            itemName = collision.gameObject.name;
            print(itemName);

            //calls function in overlord
            overlordReference.CheckItem();

            overlordReference.score += 10;
            Destroy(collision.gameObject);

            collectiblesCollected++;

            //play collect sound
            collectEffect.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.ToLower().Contains("home"))
        {
            safeZone = false;
        }
        if (collision.tag == "Block")
        {
            collision.isTrigger = false;
        }
    }
}

