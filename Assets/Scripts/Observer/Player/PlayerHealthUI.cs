using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Globalization;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private TextMeshProUGUI _healthText;
  
    private void OnEnable()
    {
        if (_playerHealth != null)
        {
            _playerHealth.OnHealthChanged += UpdateHealthText;
            _playerHealth.OnPlayerDeath += HandlePlayerDeath;
        }
    }
    private void Start()
    {
        UpdateHealthText(_playerHealth.CurrentHealth);
    }

    private void UpdateHealthText(int currentHealth)
    {
        _healthText.text = $"HEALTH: {currentHealth}";
    }

    private void HandlePlayerDeath()
    {
        
        _healthText.text = "You Died";

        
        Destroy(_playerHealth.gameObject, 0.1f);

       
    }

  
}
