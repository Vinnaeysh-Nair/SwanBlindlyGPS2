//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class LeftRightButton : MonoBehaviour
//{
//    [SerializeField] private bool isLeftButton = true;
//    [SerializeField] private Transform InventoryParents;

//    Inventory tempInventory;
//    InventorySlot[] slots1;

//    private int itemCount = 0;

//    private void Start()
//    {
//        tempInventory = Inventory.instance;
//        tempInventory.onItemChangedCallback += UpdateUI1;

//        slots1 = InventoryParents.GetComponentsInChildren<InventorySlot>();
//    }

//    void UpdateUI1()
//    {


//        for (int i = 0; i < slots1.Length; i++)
//        {
//            if (i < tempInventory.items.Count)
//            {
//                slots1[i].AddItem(tempInventory.items[i]);
//                itemCount++;
//            }
//            else
//            {
//                slots1[i].ClearSlot();
//            }
//        }
//    }

//    public void OnButtonClick()
//    {
//        tempInventory.invokeItemChanged();

//        if (isLeftButton)
//            OnLeftButtonClick();
//        else
//            OnRightButtonClick();

//        //check if there is something in items
//        Debug.Log(Inventory.instance.currentInventoryIndex);
//        //for(int i = 0; i< Inventory.instance.currentInventoryIndex; i++)
//        //{
//        //    if (i == (Inventory.instance.currentInventoryIndex - 1))
//        //        Inventory.instance.items[i - 1] = Inventory.instance.items[i];
//        //}
//        //Debug.Log(Inventory.instance.items);
//        //Inventory.instance.invokeItemChanged();
//    }

        
//     void OnLeftButtonClick()
//    {

//    }
        
//     void OnRightButtonClick()
//    {

//    }
//}