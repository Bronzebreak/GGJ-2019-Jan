using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_discription : MonoBehaviour
{
    public string currentItem;


    public void OnMouseEnter(Collider obj)
    {
        if (obj.gameObject.tag == "collect")
        {
           gameObject.GetComponent<Collectibles>().descripition = currentItem;
           
        }
    }
    
}
