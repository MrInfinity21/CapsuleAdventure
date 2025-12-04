using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;

    [SerializeField] private GameObject _inventoryCanvas;

    private void Awake()
    {
        Instance = this;
        _inventoryCanvas.SetActive(false);
    }

    public void ToggleInventory()
    {
        bool newState = !_inventoryCanvas.activeSelf;
        _inventoryCanvas.SetActive(newState);
    }
}

