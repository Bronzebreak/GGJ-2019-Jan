using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getScore : MonoBehaviour
{
    //Variables
    private GameObject Manager;

	// Use this for initialization
	void Start ()
    {
        Manager = GameObject.Find("scoreController").gameObject;
        GetComponent<TextMesh>().text = "" + Manager.GetComponent<Overlord>().score;
	}

    
}
