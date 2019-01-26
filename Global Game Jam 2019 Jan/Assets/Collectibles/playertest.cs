using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playertest : MonoBehaviour {
    //Externally Referenced Variables
    private Rigidbody2D rigBody;
    public AndrewOverlord over;
    //Action Variables
    public KeyCode moveRight;
    public KeyCode moveLeft;
    public string horizontalAxis;

    //Action Restrictions
    private bool canJump;
    public bool safeZone = false;
    public Spawner spawnReference;
    // Use this for initialization
    void Start ()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
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

    public void OnTriggerEnter2D(Collider2D trig)
    {
        print(trig.gameObject.name);
        over.CheckItem();
    }

}
