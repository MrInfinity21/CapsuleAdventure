using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollectableItem : MonoBehaviour, ICollectable
{
    [SerializeField] private int _pointValue = 10;
    [SerializeField] private InventoryItem _itemData;
    public int PointValue => _pointValue;

   
    public UnityEvent OnItemCollected;
    public UnityEvent<int> OnPointsAwarded;

    public void Collect(GameObject collector)
    {
        OnItemCollected?.Invoke();
        OnPointsAwarded?.Invoke(_pointValue);

        InventoryController.Instance.AddItemToInventory(_itemData);

        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ICollector>(out var collector))
        {
            collector.OnCollect(this);
        }
    }

    
}
