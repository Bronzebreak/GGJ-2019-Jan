using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "items", menuName = "data/items", order = 1)]
public class collectaableItems : ScriptableObject
{
    public string itemsName;
    public float score;
    public string discripition;
    public Sprite itemPic;
}
