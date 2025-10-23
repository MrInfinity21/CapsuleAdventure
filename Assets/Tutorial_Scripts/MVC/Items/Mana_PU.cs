using UnityEngine;
using UnityEngine.Events;

public class Mana_PU : MonoBehaviour, IManaCollectable
{
    [SerializeField] private int manaAmount = 20;

    public int ManaAmount => manaAmount;

    public UnityEvent OnCollected;
    public UnityEvent<int> OnHealthRestored;

    public void Collect(GameObject collector)
    {
        PlayerHealth playerHealth = collector.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.RestoreHealth(manaAmount);
            OnHealthRestored?.Invoke(manaAmount);
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
