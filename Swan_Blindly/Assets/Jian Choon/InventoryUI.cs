using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform InventoryParents;
    Inventory tempInventory;
    InventorySlot[] slots;

    void Start()
    {
        tempInventory = Inventory.instance;
        tempInventory.onItemChangedCallback += UpdateUI;

        //do this in update if inventory is constantly changing,
        //but will be more intensive
        slots = InventoryParents.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI()
    {
        for(int i=0; i< slots.Length; i++)
        {
            if (i < tempInventory.items.Count)
            {
                slots[i].AddItem(tempInventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
