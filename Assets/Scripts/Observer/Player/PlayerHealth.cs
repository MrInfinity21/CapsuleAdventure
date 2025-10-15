using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    // Event declaration using Action delegate
    public event Action<int> OnHealthChanged;
    public event Action OnPlayerDeath;

    private int _currentHealth;
    private int _maxHealth = 100;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        OnHealthChanged?.Invoke(_currentHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth = Mathf.Max(0, _currentHealth - damage);

        // Notify all observers of health change
        OnHealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            OnPlayerDeath?.Invoke();
        }
    }

    public void RestoreHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        OnHealthChanged?.Invoke(_currentHealth);

        Debug.Log($"Health restored by {amount}.Current: {_currentHealth}/{_maxHealth}");
    }
 
}