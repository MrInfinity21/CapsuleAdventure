using UnityEngine;

public class InventoryController : MonoBehaviour
{

    public static InventoryController Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _inventoryModel = new InventoryModel(maxInventoryCapacity);
    }

    [SerializeField] private InventoryView inventoryView;
    [SerializeField] private int maxInventoryCapacity = 20;

    //---

    private InventoryModel _inventoryModel;

    private void Start()
    {
        //_inventoryModel = new InventoryModel(maxInventoryCapacity);
    }

    private void OnEnable()
    {
        _inventoryModel.OnInventoryChanged += RefreshInventoryView;
    }

    private void OnDisable()
    {
        _inventoryModel.OnInventoryChanged -= RefreshInventoryView;
    }

    private void RefreshInventoryView()
    {
        inventoryView.RefreshInventory(_inventoryModel.GetAllItems());
    }
    public void AddItemToInventory(InventoryItem item)
    {
        _inventoryModel.AddItem(item);
        inventoryView.UpdateInventoryItem(item, _inventoryModel.GetItemCount(item));
    }

    public void RemoveItemFromInvetory(InventoryItem item)
    {
        _inventoryModel.RemoveItem(item);
        inventoryView.UpdateInventoryItem(item, _inventoryModel.GetItemCount(item));
    }

}
