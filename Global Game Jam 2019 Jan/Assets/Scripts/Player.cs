using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Variables
    //Script References
    public Overlord overlordReference;

    //List Compare Function Variables
    public string itemName;
    public GameObject itemToRemove;

    //Action Variables
    public string horizontalAxis;
    public bool canJump;
    public bool safeZone = false;
    public bool noJumpZone = false;
    private Rigidbody2D rigBody;

    //Audio
    public AudioSource jumpEffect;
    public AudioSource collectEffect;
    public AudioSource bGM;
    #endregion

    //Upon game start...
    void Start()
    {
        // ...retrieve my rigidbody component.
        rigBody = GetComponent<Rigidbody2D>();
    }

    //Once a frame...
    private void Update()
    {
        // ...if I'm allowed to jump...
        if (canJump == true && !safeZone)
        {
            // ...if the player presses space... 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // ...add a force impulse to my vertical axis...
                rigBody.AddForce(new Vector2(0, 75f), ForceMode2D.Impulse);

                // ...prevent me from jumping again...
                canJump = false;

                // ...and play effect sound.
                jumpEffect.Play();       
            }
        }

        // ...if I'm in a safeZone (i.e. the house)...
        if (safeZone)
        {
            // ...retrieve the horizontal input axis value...
            float moveHori = Input.GetAxis(horizontalAxis);

            // ...then, I move horizontally based on the horizontal input.
            rigBody.velocity = new Vector2(moveHori * 3.75f, rigBody.velocity.y);
        }

        // ...if I'm NOT in a safeZone...
        else
        {
            // ...I'm constantly moving to the right.
            rigBody.velocity = new Vector2(5, rigBody.velocity.y);
        }
    }

    //If I stay overlapped with an object...
    private void OnTriggerStay2D(Collider2D collision)
    {
        // ...and the object is 'ground'...
        if (collision.gameObject.name.ToLower().Contains("ground"))
        {
            // ...I can jump.
            canJump = true;
        }
    }

    //When I collide with a trigger...
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ...if it is the house...
        if (collision.tag == "House")
        {
            // ...I am in a safe zone.
            safeZone = true;
        }

        // ...if it is a collectible...
        if (collision.tag == "Collectible")
        {
            // ...the name of the object collided with is stored in a variable...
            itemName = collision.gameObject.name;

            // ...and then a function in Overlord is run...
            overlordReference.CheckItem();

            // ...then, for every item that has yet to be collected in the overlord's collectible list...
            foreach (GameObject listedObject in overlordReference.collectiblesList)
            {
                // ...if the object collided with is the same...
                if (itemName.Contains(listedObject.name))
                {
                    // ...store that item in a variable.
                    itemToRemove = listedObject;
                }
            }

            // ...then, remove item from list...
            overlordReference.collectiblesList.Remove(itemToRemove);

            // ...increase my score...
            overlordReference.score += 10;

            // ...destroy the object that I collided with...
            Destroy(collision.gameObject);

            // ...and play the collect sound effect.
            collectEffect.Play();
        }
    }

    //When I leave a trigger...
    private void OnTriggerExit2D(Collider2D collision)
    {
        // ...if it was the house...
        if (collision.tag == "House")
        {
            // ...I am no longer in a safe zone.
            safeZone = false;
        }
    }
}