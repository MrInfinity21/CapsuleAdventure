using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;

    [SerializeField] private Transform inventoryHolder;

    [SerializeField] private InventoryItemView itemViewPrefab;


    private Dictionary<InventoryItem, InventoryItemView> _itemViews = new Dictionary<InventoryItem, InventoryItemView>();


    public void OpenInventory()
    {
        inventoryPanel.SetActive(true);
    }
    public void RefreshInventory(Dictionary<InventoryItem, int> items)
    {
        _itemViews.Clear();

        // clear all the ui elements in the inventory holder
        foreach(Transform child in inventoryHolder)
        {
            Destroy(child.gameObject);
        }


        foreach(var item in items.Keys)
        {
            var inventoryItemView = Instantiate(itemViewPrefab, inventoryHolder);
            _itemViews.Add(item, inventoryItemView);
            inventoryItemView.SetItem(item, items[item]);
        }
        

    }

    public void UpdateInventoryItem(InventoryItem item, int itemCount)
    {
        if (_itemViews.ContainsKey(item))
        {
            if(itemCount <= 0)
            {
                Destroy(_itemViews[item]);
                _itemViews.Remove(item);
                
            }

            _itemViews[item].SetItemCount(itemCount);
        }
    }
}
