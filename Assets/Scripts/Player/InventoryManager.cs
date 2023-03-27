using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public class InventorySlot {
        public Item item;
        public int quantity;
    }

    public static InventoryManager Instance;
    public Item emptyItem;
    public List<InventorySlot> inventory = new();
    public int selectedSlot;

    

    private void Awake()
    {
        Instance = this;
        selectedSlot = 0;

        //should be changed
        for (int i = 0; i<=5;i++){
            inventory.Add(new InventorySlot{item = emptyItem, quantity = 0});
        }
    }

    public void Update()
    {
        //should probably be changed
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            selectedSlot = 0;
            Debug.Log(inventory[selectedSlot].item.itemName +" amount "+ inventory[selectedSlot].quantity + " in slot "+ (selectedSlot+1));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedSlot = 1;
            Debug.Log(inventory[selectedSlot].item.itemName +" amount "+ inventory[selectedSlot].quantity+ " in slot "+ (selectedSlot+1));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedSlot = 2;
            Debug.Log(inventory[selectedSlot].item.itemName +" amount "+ inventory[selectedSlot].quantity + " in slot "+ (selectedSlot+1));
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedSlot = 3;
            Debug.Log(inventory[selectedSlot].item.itemName +" amount "+ inventory[selectedSlot].quantity + " in slot "+ (selectedSlot+1));
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedSlot = 4;
            Debug.Log(inventory[selectedSlot].item.itemName +" amount "+ inventory[selectedSlot].quantity + " in slot "+ (selectedSlot+1));
        }

        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Attack();
        }
    }

    public void AddItem(Item item)
    {
            for(int i =0; i<=inventory.Capacity;i++){
                if(item.id == inventory[i].item.id && item.stackable){
                    inventory[i].quantity++;
                    Debug.Log("increase quantity for item '"+ item.itemName + "' in slot:" + (i+1));
                    
                    return;
                }
                if (inventory[i].item.id == 0){
                    inventory[i] = new InventorySlot{item=item, quantity = 1};
                    Debug.Log("new item stored in slot:" + (i+1));
                    return;
                }
        }
    }

    public void RemoveItem(Item item)
    {
        // inventory.Remove(item);
    }

    public void Attack(){
        RaycastHit target;
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward, out target, 3)){
            if(target.collider.tag == "Enemy"){
                target.collider.gameObject.GetComponent<Enemy>().health -= inventory[selectedSlot].item.damage;
            }
            Debug.Log(target.collider.gameObject.name);
        }
    }
}


