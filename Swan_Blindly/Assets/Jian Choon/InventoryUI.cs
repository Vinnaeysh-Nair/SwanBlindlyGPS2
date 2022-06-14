using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform InventoryParents;
    //[SerializeField] private Transform player;

    Inventory tempInventory;
    InventorySlot[] slots;

    private int itemCount = 0;

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
                itemCount++;
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    /*public void dropItem()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i == (itemCount-1))
            {
                Vector3 itemDropLocation = new Vector3(player.position.x, player.position.y, player.position.z + 1f);
                Instantiate(slots[i], itemDropLocation, Quaternion.identity);
                //ScriptableObject.CreateInstance<Item>();
            }
        }
    }*/
}
