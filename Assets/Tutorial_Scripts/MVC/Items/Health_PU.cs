using UnityEngine;
using UnityEngine.Events;

public class Health_PU : MonoBehaviour, ILifeCollectable
{
    [SerializeField] private int healthAmount = 20;
    [SerializeField] private InventoryItem _itemData;

    public int HealthAmount => healthAmount;

    public UnityEvent OnCollected;


    public void Collect(GameObject collector)
    {
        OnCollected?.Invoke();
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            
            InventoryController.Instance.AddItemToInventory(_itemData);
            Destroy(gameObject);
        }
    }

}
