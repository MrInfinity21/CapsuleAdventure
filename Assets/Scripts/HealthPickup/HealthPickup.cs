using UnityEngine;
using UnityEngine.Events;
public class HealthPickup : MonoBehaviour, IHealthCollectable
{
    [SerializeField] private int _healthAmount = 20;

    public int HealthAmount => _healthAmount;

    public UnityEvent OnCollected;
    public UnityEvent<int> OnHealthRestored;

    public void Collect(GameObject collector)
    {
        PlayerHealth playerHealth = collector.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            
            if (playerHealth.CurrentHealth < playerHealth.MaxHealth)
            {
                playerHealth.RestoreHealth(_healthAmount);
                OnHealthRestored?.Invoke(_healthAmount);

                OnCollected?.Invoke();
                Destroy(gameObject);
            }

        }
        
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            Collect(other.gameObject);
        }
    }
}
