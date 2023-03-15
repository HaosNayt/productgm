using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> inventory = new();

    private void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            Debug.Log(inventory[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log(inventory[1]);
        }
    }

    public void AddItem(Item item)
    {
        inventory.Add(item);
    }

    public void RemoveItem(Item item)
    {
        inventory.Remove(item);
    }
}
