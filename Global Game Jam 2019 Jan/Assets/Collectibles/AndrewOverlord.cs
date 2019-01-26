using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndrewOverlord : MonoBehaviour {
    public playertest playerRefTest;
    int i = 0;
    public GameObject[] obj;

	// Use this for initialization
	void Start () {
	}
	public void CheckItem()
    {
        foreach (GameObject trig in obj)
        {

            if (trig.gameObject.name == obj[i].name)
            {
                
                obj[i].gameObject.SetActive(true); 
            }
            else
            {
                i++;
                CheckItem();
            }
        }
    }
	// Update is called once per frame
	void Update ()
    {
		if (i >= (obj.Length - 1))
        {
            i = 0;
        }
	}
}
