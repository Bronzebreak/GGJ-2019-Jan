using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_prefabs : MonoBehaviour
{
    //Variables
    public GameObject floor;
    
	void Start ()
    {
	
	}
	
	
	void Update ()
    {
    
	}

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Old_floor")
        {
            Destroy(this.gameObject);
        }
    }
}
