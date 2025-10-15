using UnityEngine;
using TMPro;
using UnityEngine.UI;

using System.Globalization;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Image _foregroundImage;
    [SerializeField] private Image _backgorundImage;
  
    private void OnEnable()
    {
        if (_playerHealth == null)
            _playerHealth = FindFirstObjectByType<PlayerHealth>();

        if (_playerHealth != null)
        {
            _playerHealth.OnHealthChanged += UpdateHealthBar;
            _playerHealth.OnPlayerDeath += HandlePlayerDeath;

            UpdateHealthBar(_playerHealth.CurrentHealth);
        }
    }

    private void OnDisable()
    {
        if (_playerHealth != null)
        {
            _playerHealth.OnHealthChanged -= UpdateHealthBar;
            _playerHealth.OnPlayerDeath -= HandlePlayerDeath;
        } 
    }
    
    private void UpdateHealthBar(int currentHealth)
    {
        if (_playerHealth == null) return;

        float fillValue = (float)currentHealth / _playerHealth.MaxHealth;
        _foregroundImage.fillAmount = fillValue;

    }

    private void HandlePlayerDeath()
    {

        Debug.Log("[PlayerHealthUI] Player Died!");
        _foregroundImage.fillAmount = 0f;   
    }

  
}
