using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region Variables
    //Externally Referenced Variables
    private Rigidbody2D rigBody;

    //Action Variables
    public KeyCode moveRight;
    public KeyCode moveLeft;
    public string horizontalAxis;

    //Action Restrictions
    private bool canJump;
    public bool safeZone = false;
    public Script_RandomObstacle spawnReference;

    /*  Animation Notes
    Variables:
    private SpriteRenderer myRenderer;
    public Sprite[] animations;
    Start: Retrieves the sprite renderer component attached to this game object.
    myRenderer = GetComponent<SpriteRenderer>();
    Function:  
    myRenderer.sprite = animations[0];
    */
    #endregion

    void Start()
    {
        //Retrieves the rigidbody component attached to this game object.
        rigBody = GetComponent<Rigidbody2D>();
    }

    //Multiple times a frame...
    void FixedUpdate()
    {
        #region Jump
        //If player is allowed to jump...
        if (canJump == true)
        {
            // ...if player presses space... 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //...the character applies a force impulse to the vertical axis...
                rigBody.AddForce(new Vector2(0, 5.0f), ForceMode2D.Impulse);

                //... and the player can no longer jump.
                canJump = false;
            }
        }
        #endregion

        #region Movement
        if (safeZone)
        {
            // ...retrieve the horizontal input axis value.
            float moveHori = Input.GetAxis(horizontalAxis);

            // ...then, move horizontally based on the horizontal input; do NOT affect vertical movement.
            rigBody.velocity = new Vector2(moveHori * 5.0f, rigBody.velocity.y);
        }
        else
        {
            rigBody.velocity = new Vector2(5, rigBody.velocity.y);
        }
        #endregion
    }

    //Upon collision with an object...
    private void OnCollisionEnter2D(Collision2D collision)
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.ToLower().Contains("home"))
        {
            safeZone = false;
        }
    }
}

