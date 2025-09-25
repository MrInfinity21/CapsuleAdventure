using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 10;
    [SerializeField] private float _damageInterval = 1f;

    private float _nextDamageTime;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Time.time >= _nextDamageTime)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(_damageAmount);
                _nextDamageTime = Time.time + _damageInterval;
            }
        }
    }
}
