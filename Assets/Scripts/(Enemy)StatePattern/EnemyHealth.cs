using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth = 10;
    private int _currentHealth;

    public int MaxHealth => _maxHealth;
    public int CurrentHealth => _currentHealth;

    private EnemyHealthBarUI _healthBar;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _healthBar = GetComponentInChildren<EnemyHealthBarUI>();

        if (_healthBar != null)
            _healthBar.Initialize(this);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_healthBar != null)
            _healthBar.UpdateHealthBar(_currentHealth, _maxHealth);

        Debug.Log($"{gameObject.name} took {damage} damage! Remaining : {_currentHealth}");

        if(_currentHealth <= 0 )
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log($"{gameObject.name} died!");
        Destroy(gameObject);
    }
}
