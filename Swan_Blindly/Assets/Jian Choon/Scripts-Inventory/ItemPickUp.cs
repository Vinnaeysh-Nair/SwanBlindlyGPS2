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

            Inventory.instance.invokeItemChanged();
            
            Destroy(gameObject);
        }
    }
}
