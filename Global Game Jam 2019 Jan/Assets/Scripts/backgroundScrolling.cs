using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScrolling : MonoBehaviour
{
    //Variables
    Material mat;

    // Background
    Vector2 bgOffSet;
    public float xVel, yVel;
    public bool isScrolling = false;

    //Script refrences
    public Overlord overlordRef;
    public Player playerRef;

  
    private void Awake()
    {
        // sets the 'mat' to render to the material
        mat = GetComponent<Renderer>().material;
    }

    void Start ()
    {
        //sets te screen scoll to false on loading into the game
        isScrolling = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if the player is in the safe zone, or the the the player is stopped, stop the scrolling background
        if (playerRef.safeZone || overlordRef.freezeScore)
        {
            //sets scrolling background to false
            isScrolling = false;
        }

        // if the player is not in the zone, and the score is not frozen, set the background scrolling to true.
        if(!playerRef.safeZone && !overlordRef.freezeScore)
        {
            //sets the scrolling to true
            isScrolling = true;
        }
       



        //if the scrolling is true, move the background
        if (isScrolling == true)
        {
            //set the offset to a new vector position
            bgOffSet = new Vector2(xVel, yVel);
            //move the background via a time delta time
            mat.mainTextureOffset += bgOffSet * Time.deltaTime;
        
        }

        // if the scrolling is false, print in editor
        else if (isScrolling == false)
        {
            //prints in editor
            //print("NOT MOVEING");
        }
       
    }
}
