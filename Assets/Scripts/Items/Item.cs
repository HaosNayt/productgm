using UnityEngine;

[CreateAssetMenu(fileName = "New item", order = 51)]
public class Item : ScriptableObject
{
    public enum ItemTypes
    {
        weapon,
        consumable,
        resource,
        empty,
    }

    public int id;
    public string itemName;
    public bool stackable;
    public ItemTypes ItemType = ItemTypes.empty;
    public int damage = 1;
}
