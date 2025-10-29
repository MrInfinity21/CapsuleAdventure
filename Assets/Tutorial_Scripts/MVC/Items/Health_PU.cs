using UnityEngine;
using UnityEngine.Events;

public class Health_PU : MonoBehaviour, ILifeCollectable
{
    [SerializeField] private int healthAmount = 20;

    public int HealthAmount => healthAmount;

    public UnityEvent OnCollected;
    public UnityEvent<int> OnHealthRestored;

    public void Collect(GameObject collector)
    {
        PlayerHealth playerHealth = collector.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.RestoreHealth(healthAmount);
            OnHealthRestored?.Invoke(healthAmount);
        }

        OnCollected?.Invoke();
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            Collect(other.gameObject);
        }
    }

}
