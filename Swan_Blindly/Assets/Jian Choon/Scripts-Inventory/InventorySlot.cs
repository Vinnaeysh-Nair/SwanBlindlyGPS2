using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    Item tempItem;

    public void AddItem(Item newItem)
    {
        tempItem = newItem;

        icon.sprite = tempItem.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        tempItem = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void useItem()
    {
        tempItem.use();
        Inventory.instance.removeItem(tempItem);
    }
}
