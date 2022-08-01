using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;

    public override void pickUpItem()
    {
        base.pickUpItem();

        PickUp();
    }

    void PickUp()
    {
        bool isPickedUp = Inventory.instance.addItem(item);
        if (isPickedUp)
        {
            Inventory.instance.currentInventoryIndex++;

            //Inventory.instance.itemsTemp.Enqueue(item);
            //Debug.Log("Enqueued: " + item.name);

            Inventory.instance.invokeItemChanged();
            
            Destroy(gameObject);
        }
    }
}
