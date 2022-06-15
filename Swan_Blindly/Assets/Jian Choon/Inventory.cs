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

    [SerializeField] private int inventorySpaceLimit = 5;

    public List<Item> items = new List<Item>();

    public bool addItem(Item itemTemp)
    {
        if(items.Count >= inventorySpaceLimit)
        {
            Debug.Log("Insuffiecient space");
            return false;
        }
        items.Add(itemTemp);

        invokeItemChanged();

        return true;
    }

    public void removeItem(Item itemTemp)
    {
        items.Remove(itemTemp);

        invokeItemChanged();
    }

    void invokeItemChanged()
    {
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
