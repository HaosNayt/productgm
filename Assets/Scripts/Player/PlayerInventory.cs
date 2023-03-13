using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public InventorySlot[] inventorySlots = new InventorySlot[5];

    public int selectedSlot = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            selectedSlot = 0;
            Debug.Log(inventorySlots[selectedSlot]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedSlot = 1;
            Debug.Log(inventorySlots[selectedSlot]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedSlot = 2;
            Debug.Log(inventorySlots[selectedSlot]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedSlot = 3;
            Debug.Log(inventorySlots[selectedSlot]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedSlot = 4;
            Debug.Log(inventorySlots[selectedSlot]);
        }
    }
}

public class InventorySlot{
    int itemID;
    string itemName;
    string quantity;
    bool stackable;
}