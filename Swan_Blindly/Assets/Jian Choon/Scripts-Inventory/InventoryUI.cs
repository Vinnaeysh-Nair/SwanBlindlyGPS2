using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform InventoryParents;
    //[SerializeField] private Transform player;

    Inventory tempInventory;
    InventorySlot[] slots;

    private bool isFirst = true;

    private int itemCount = 0;
    private int index;
    private int tempIndex;

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
        for (int i=0; i< slots.Length; i++)
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

    //new step 2
    /*public void nextItemRight()
    {
        calculateIndex();
        
        slots[tempIndex].swapItemRight(tempInventory.items[tempIndex]);
        tempIndex--;

        if(tempIndex < 0)
        {
            tempIndex = tempInventory.currentInventoryIndex;
        }
    }*/

    /*public void nextItemLeft()
    {
        
        tempIndex = index;
        
        slots[index].swapItemLeft(tempInventory.items[index]);
        //tempIndex++;

        *//*if ( index != 0)
        {
            index = 0;
        }
        if(index > 0 && index<=tempInventory.inventorySpaceLimit)
            index++;*//*

    }*/

    private void calculateIndex()
    {
        index = tempInventory.swapItemsRight();
        if (isFirst)
        {
            index--;
            tempIndex = index;
            isFirst = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown("p"))
        {
            
        }
        else if(Input.GetKeyDown("l"))
        {
            
        }
    }
}
