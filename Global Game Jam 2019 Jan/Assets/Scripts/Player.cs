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
    public Spawner spawnerReference;
    public string itemName;
    public int collectiblesCollected;
    public GameObject itemToRemove;

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
            // ...the name of the object collided is stored in a variable...
            itemName = collision.gameObject.name;

            // ...and then a function in Overlord is run...
            overlordReference.CheckItem();

            // ...then, for every listed item...
            foreach (GameObject listedObject in spawnerReference.collectiblesList)
            {
                // ...compare name of collided item with name in list, and if there's a match...
                if (itemName.Contains(listedObject.name))
                {
                    // ...store that item in a variable.
                    itemToRemove = listedObject;
                }
            }
            // ...then, remove variable item from list...
            spawnerReference.collectiblesList.Remove(itemToRemove);

            // ...increase score...
            overlordReference.score += 10;

            // ...destroy the collided object...
            Destroy(collision.gameObject);

            // ...increase the quantity of collectibles obtained...
            collectiblesCollected++;

            //... and play the collect sound.
            collectEffect.Play();
        }
    }

    //When you leave a trigger...
    private void OnTriggerExit2D(Collider2D collision)
    {
        // ...if it's home...
        if (collision.gameObject.name.ToLower().Contains("home"))
        {
            // ...the player is no longer in a safe zone.
            safeZone = false;
        }

        // ...if it's the blocking volume...
        if (collision.tag == "Block")
        {
            // ...the block can no longer be triggered.
            collision.isTrigger = false;
        }
    }
}

