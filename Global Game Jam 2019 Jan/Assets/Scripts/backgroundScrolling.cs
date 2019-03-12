using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScrolling : MonoBehaviour
{
    Material mat;
    Vector2 bgOffSet;

    public float xVel, yVel;

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
        bgOffSet = new Vector2(xVel, yVel);
        mat.mainTextureOffset += bgOffSet * Time.deltaTime;
	}
}
