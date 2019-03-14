using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    #region Variables
    //Background
    Vector2 bgOffSet;
    public float xVel, yVel;
    public bool isScrolling = false;
    Material mat;

    //Script References
    public Overlord overlordRef;
    public Player playerRef;
    #endregion

    //Upon game start...
    private void Start()
    {
        // ...set variable to my renderer component's material.
        mat = GetComponent<Renderer>().material;
    }
	
	//Once a frame...
	void Update ()
    {
        // ...if the player is not in a safe zone AND not stopped...
        if (!playerRef.safeZone && !overlordRef.freezeScore)
        {
            // ...I can scroll.
            isScrolling = true;
        }

        // ...if the player is in a safe zone and/or is stopped...
        else
        {
            // ...I stop scrolling.
            isScrolling = false;
        }

        // ...if I can scroll...
        if (isScrolling == true)
        {
            // ...increase my offset vector...
            bgOffSet = new Vector2(xVel, yVel);

            // ...and move my texture based off of the difference in time between offsets.
            mat.mainTextureOffset += bgOffSet * Time.deltaTime;
        }      
    }
}
