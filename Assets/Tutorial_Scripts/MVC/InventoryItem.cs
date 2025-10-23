using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "Scriptable Objects/InventoryItem")]
public class InventoryItem : ScriptableObject
{
    public string itemName;

    public Sprite itemIcon;

    public float itemValue;

    [TextArea] public string itemDescription;
}
