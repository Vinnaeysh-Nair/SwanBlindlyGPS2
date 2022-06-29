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
        //method 1 - still testing
        if (isFirst)
        {
            index = tempInventory.swapItemsRight();
            isFirst = false;
        }
        index--;
        slots[index].swapItem(tempInventory.items[index]);

        //method 2 - kidda works
        //int index = tempInventory.currentInventoryIndex;
        //index--;
        //slots[index].swapItem(tempInventory.items[index]);
    }

    private void Update()
    {
        if(Input.GetKeyDown("p"))
        {
            Debug.Log(tempInventory.currentInventoryIndex);
        }
        else if(Input.GetKeyDown("l"))
        {
            Debug.Log("Empty for now");
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
