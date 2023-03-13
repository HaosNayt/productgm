using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    private ItemsData itemData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // player.GetComponent<PlayerInventory>().inventorySlots[1]

    }
}
