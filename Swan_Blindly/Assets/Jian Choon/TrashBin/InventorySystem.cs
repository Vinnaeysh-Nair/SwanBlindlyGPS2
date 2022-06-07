using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public ItemInventoryData data { get; private set; }
    public int stackSize { get; private set; }

    public InventoryItem(ItemInventoryData source)
    {
        data = source;
        AddToStack();
    }

    public void AddToStack()
    {
        stackSize++;
    }

    public void removeFromStack()
    {
        stackSize--;
    }
}

public class InventorySystem : MonoBehaviour
{
    private Dictionary<ItemInventoryData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory { get; private set; }

    void Awake()
    {
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<ItemInventoryData, InventoryItem>();
    }

    public void Add(ItemInventoryData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
        }
    }

    public void Remove(ItemInventoryData referenceData)
    {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.removeFromStack();

            if(value.stackSize == 0)
            {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }
        }
    }
}
