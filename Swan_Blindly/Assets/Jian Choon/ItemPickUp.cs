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
        Debug.Log("Picking up " + item.name);
        bool isPickedUp = Inventory.instance.addItem(item);
        if(isPickedUp)
            Destroy(gameObject);
    }
}
