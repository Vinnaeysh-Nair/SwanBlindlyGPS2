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
    public void nextItemRight()
    {
        index = tempInventory.swapItemsRight();
        if (isFirst)
        {
            index--;
            tempIndex = index;
            isFirst = false;
        }
        Debug.Log(index);
        Debug.Log(tempIndex);
        slots[tempIndex].swapItem(tempInventory.items[tempIndex]);
        
        tempIndex--;
        if(tempIndex ==0)
        {
            tempIndex = index;
        }

        //logic to return back to the first
        /*if(index == -1)
        {

        }*/
    }

    public void nextItemLeft()
    {
        if ( index != 0)
        {
            index = 0;
        }
        if(index > 0 && index<=tempInventory.inventorySpaceLimit)
            index++;

        slots[index].swapItem(tempInventory.items[index]);
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
