using UnityEngine;
using UnityEngine.Events;
public class StaminaPickup : MonoBehaviour, IStaminaCollectable
{
    [SerializeField] private int _staminaAmount = 20;

    public int StaminaAmount => _staminaAmount;

    public UnityEvent OnCollected;
    public UnityEvent<int> OnStaminaRestored;

    public void Collect(GameObject collector)
    {
        if (collector.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            playerMovement.RestoreStamina(_staminaAmount);
            OnStaminaRestored?.Invoke(_staminaAmount);
        }

        OnCollected?.Invoke();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerMovement>(out var playerStamina))
        {
            Collect(other.gameObject);
        }
    }
}
