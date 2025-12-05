using UnityEngine;
using UnityEngine.Events;
public class StaminaPickup : MonoBehaviour, IStaminaCollectable
{
    [SerializeField] private int _staminaAmount = 20;
    [SerializeField] private InventoryItem _itemData;
    public int StaminaAmount => _staminaAmount;

    public UnityEvent OnCollected;
    public UnityEvent<int> OnStaminaRestored;

    public void Collect(GameObject collector)
    {
        PlayerMovement playerMovement = collector.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            if (playerMovement.GetCurrentStamina() < playerMovement.GetMaxStamina())
            {
                playerMovement.RestoreStamina(_staminaAmount);
                OnStaminaRestored?.Invoke(_staminaAmount);

                InventoryController.Instance.AddItemToInventory(_itemData);

                OnCollected?.Invoke();
                Destroy(gameObject);
            }
    
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            if (playerMovement.GetCurrentStamina() < playerMovement.GetMaxStamina())
            { 
                Collect(other.gameObject); 
            } 
        }
    }
}
