using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AndrewOverlord : MonoBehaviour
{
    //Player reference
    public playertest playerRefTest;
    //Index for spawn list
    int b = 0;
    //List length
    int listLength;
    //Array with game objects 
    public GameObject[] obj;
    public List<GameObject> collectiblesList;
    // Use this for initialization
    void Start ()
    {

	}
    //checks if item is in the list and array...
	public void CheckItem()
    {
        for(int i = 0; i < obj.Length; i++)
        {
            //goes through all elements of the array and list.
            b=i; 
            if (playerRefTest.itemName == obj[i].name)
            {
                //If object is in the array set it active
                obj[i].gameObject.SetActive(true);
                //Empties the list element so it doesnt spawn again
                collectiblesList[b] = null;
            }
            else
            {
                b = i;  
            }
        }
    }
	// Update is called once per frame
	void Update ()
    {
        //sets varieable to list length
        listLength = collectiblesList.Count;
        //If index goes out of range sets it to 0
        if (b >= (listLength - 1))
        {
            b = 0;
        }
	}
}
