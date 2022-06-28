using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region SingleTon
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Too many instance of inventory is found!!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int inventorySpaceLimit = 5;
    public int currentInventoryIndex = 0;
    
    public List<Item> items = new List<Item>();

    public bool addItem(Item itemTemp)
    {
        if(items.Count >= inventorySpaceLimit)
        {
            Debug.Log("Insuffiecient space");
            return false;
        }
        
        currentInventoryIndex++;
        items.Add(itemTemp);

        invokeItemChanged();

        return true;
    }

    public void removeItem(Item itemTemp)
    {
        items.Remove(itemTemp);

        invokeItemChanged();
    }

    public void invokeItemChanged()
    {
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    
    
    
    

    //void Update()
    //{
        
        
        
    //    int prevSelectedWeapon = selectedWeapon;


    //    //Scroll wheel to change weapon
    //    if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
    //    {
    //        if (!IsNextWeaponUnlocked())
    //        {
    //            int temp = FindNextUnlockedWeapon();
    //            selectedWeapon = temp;
    //        }
    //        else
    //        {
    //            if (selectedWeapon >= transform.childCount - 1)
    //                selectedWeapon = 0;
    //            else
    //                selectedWeapon++;
    //        }
    //    }

    //    if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
    //    {

    //        if (!IsPrevWeaponUnlocked())
    //        {
    //            int temp = FindPrevUnlockedWeapon();
    //            selectedWeapon = temp;

    //        }
    //        else
    //        {
    //            if (selectedWeapon <= 0)
    //                selectedWeapon = transform.childCount - 1;
    //            else
    //                selectedWeapon--;
    //        }
    //    }


    //    //Changing through num keys
    //    for (int i = 0; i < 10; i++)
    //    {
    //        if (Input.GetKeyDown((KeyCode)(48 + i)) && transform.childCount >= i)
    //        {
    //            //avoid getting null reference when pressing '0'
    //            if (i == 0) return;

    //            if (!IsSpecificWeaponUnlocked(i - 1)) return;
    //            selectedWeapon = i - 1;
    //        }
    //    }


    //    if (prevSelectedWeapon != selectedWeapon)
    //    {
    //        StartingWeapon();
    //        WeaponIsSwitched();
    //    }
    //}
}
