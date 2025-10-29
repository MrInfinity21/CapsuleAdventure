using UnityEngine;
using UnityEngine.Events;

public class Carrot_PU : MonoBehaviour, ICarrotCollectable
{
    [SerializeField] private int carrotAmount = 20;

    public int CarrotAmount => carrotAmount;

    public UnityEvent OnCollected;
    public UnityEvent<int> OnHealthRestored;

    public void Collect(GameObject collector)
    {
        PlayerHealth playerHealth = collector.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.RestoreHealth(carrotAmount);
            OnHealthRestored?.Invoke(carrotAmount);
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
