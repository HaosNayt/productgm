using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New item",order =51)]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public bool stackable;

}
