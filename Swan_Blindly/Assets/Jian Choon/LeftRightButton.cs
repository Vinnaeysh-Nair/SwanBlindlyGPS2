using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftRightButton : MonoBehaviour
{
    private Queue<Item> itemsTemp = new Queue<Item>();
    
    

    public void OnRightButtonClick()
    {
        Debug.Log(Inventory.instance.currentInventoryIndex);
        for (int i = 0; i < Inventory.instance.currentInventoryIndex; i++)
        {
            itemsTemp.Enqueue(Inventory.instance.items[i]);
        }
        //use stack
        itemsTemp.Dequeue();
    }
}

//for (int j = 0; j < Inventory.instance.inventorySpaceLimit; j++)
//{
//    if (Inventory.instance.items[j] == itemTemp)
//    {
//        Inventory.instance.items[j] = itemTemp;
//        Inventory.instance.currentInventoryIndex--;
//    }
//    Inventory.instance.invokeItemChanged();
//}