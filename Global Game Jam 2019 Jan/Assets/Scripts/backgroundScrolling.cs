using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScrolling : MonoBehaviour
{
    //Variables
    Material mat;
    Vector2 bgOffSet;

    public float xVel, yVel;
    public bool isScrolling = false;
    public Overlord overLord;

  
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
        //if the player is in a safezone, set the scolling to false
        if (overLord.freezeScore  == true)
        {
            //sets the scrolling to false
            isScrolling = true;
        }

        // if the player is not in th esafe zone, set ht e scrolling to false
        else if(overLord.freezeScore == false)
        {
            //sets the scrolling to ture
            isScrolling = false;
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
            print("NOT MOVEING");
        }
       
    }
}
