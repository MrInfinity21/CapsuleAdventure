using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InventoryItemView : MonoBehaviour
{

    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text itemCount;

    public void SetItem(InventoryItem item, int count)
    {
        itemImage.sprite = item.itemIcon;
        itemCount.text = $"x{count}"; //x1, x2, x3, x99
    }

    public void SetItemCount(int count)
    {
        itemCount.text = $"x{count}"; // x1, x2, x3, x99
    }

}
    