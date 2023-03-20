using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void Pickup()
    {
        InventoryManager.Instance.AddItem(item);
        Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player"){
            Pickup();
        }
    }
}
