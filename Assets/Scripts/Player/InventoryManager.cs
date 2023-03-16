using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public Item emptyItem;
    public List<InventorySlot> inventory = new();
    [SerializeField] int selectedSlot;

    private void Awake()
    {
        Instance = this;
        selectedSlot = 0;
        for (int i = 0; i<=5;i++){
            inventory.Add(new InventorySlot{item = emptyItem, quantity = 0});
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            selectedSlot = 0;
            Debug.Log(inventory[selectedSlot].item.name +" amount "+ inventory[selectedSlot].quantity + " in slot "+ selectedSlot);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedSlot = 1;
            Debug.Log(inventory[selectedSlot].item.name +" amount "+ inventory[selectedSlot].quantity+ " in slot "+ selectedSlot);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedSlot = 2;
            Debug.Log(inventory[selectedSlot].item.name +" amount "+ inventory[selectedSlot].quantity + " in slot "+ selectedSlot);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedSlot = 3;
            Debug.Log(inventory[selectedSlot].item.name +" amount "+ inventory[selectedSlot].quantity + " in slot "+ selectedSlot);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedSlot = 4;
            Debug.Log(inventory[selectedSlot].item.name +" amount "+ inventory[selectedSlot].quantity + " in slot "+ selectedSlot);
        }
    }

    public void AddItem(Item item)
    {
            for(int i =0; i<=inventory.Capacity;i++){
                if(item.id == inventory[i].item.id && item.stackable){
                    inventory[i].quantity++;
                    Debug.Log("increase quantity for item '"+ item + "' in slot:" + i);
                    
                    return;
                }
                if (inventory[i].item.id == 0){
                    inventory[i] = new InventorySlot{item=item, quantity = 1};
                    Debug.Log("new item stored in slot:" + i);
                    return;
                }
        }
    }

    public void RemoveItem(Item item)
    {
        // inventory.Remove(item);
    }
}

public class InventorySlot{
    public Item item;
    public int quantity;
}
