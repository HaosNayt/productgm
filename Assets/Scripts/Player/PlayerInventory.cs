using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private object[] inventorySlots = new object[5];

    public int currentSlot = 0;

    // Start is called before the first frame update
    void Start()
    {
        inventorySlots[0] = 
            new {id = "1", quantity = "1" , name = "Sword"};
        inventorySlots[1] =
            new { id = "2", quantity = "15", name = "Meat" };
        inventorySlots[2] =
            new { id = "0", quantity = "0", name = "Nothing" };
        inventorySlots[3] =
            new { id = "0", quantity = "0", name = "Nothing" };
        inventorySlots[4] =
            new { id = "0", quantity = "0", name = "Nothing" };

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            currentSlot = 0;
            Debug.Log(inventorySlots[currentSlot]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSlot = 1;
            Debug.Log(inventorySlots[currentSlot]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSlot = 2;
            Debug.Log(inventorySlots[currentSlot]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentSlot = 3;
            Debug.Log(inventorySlots[currentSlot]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentSlot = 4;
            Debug.Log(inventorySlots[currentSlot]);
        }
    }
}
