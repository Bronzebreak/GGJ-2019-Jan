using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScrolling : MonoBehaviour
{
    Material mat;
    Vector2 bgOffSet;

    public float xVel, yVel;
    public bool isScrolling = false;
    public Player player;

    // Use this for initialization


    private void Awake()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*
        if (GetComponent<Player>().safeZone == true)
        {
            isScrolling = true;
        }

        else if(GetComponent<Player>().safeZone == false)
        {
            isScrolling = false;
        }



        if (isScrolling == true)
        {
        */
            bgOffSet = new Vector2(xVel, yVel);
            mat.mainTextureOffset += bgOffSet * Time.deltaTime;
        /*
        }

        else if (isScrolling == false)
        {
            print("NOT MOVEING");
        }
        */
    }
}
