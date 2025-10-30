using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel
{
    // create a dictionary to hold inventory items and their quantities

    private Dictionary<InventoryItem, int> _items = new Dictionary<InventoryItem, int>();

    private int _maxCapacity = 20;

    public event Action OnInventoryChanged;

    public InventoryModel(int maxCapacity)
    {
        _maxCapacity = maxCapacity;
    }

    public void AddItem(InventoryItem item)
    {
        if (_items.ContainsKey(item))
        {
            _items[item]++;
        }
        else
        {   if (_items.Count < _maxCapacity)
            {
                _items.Add(item, 1);
                OnInventoryChanged?.Invoke();
            }

            else
            {
                Debug.Log("Inventory is FULL!");
            }
            
        }
    }

    public void RemoveItem(InventoryItem item)
    {
        if (_items.ContainsKey(item))
        {
            _items[item]--;

            if(_items[item] <= 0) // no items of this type in the inventory now
            {
                _items.Remove(item);
            }
        }
    }

    public int GetItemCount(InventoryItem item)
    {
        if (_items.ContainsKey(item))
        {
            return _items[item];
        }
        return 0;
    }

    public Dictionary<InventoryItem, int> GetAllItems()
    {
        return _items;
    }
    // method to add an item to the inventory 
}
