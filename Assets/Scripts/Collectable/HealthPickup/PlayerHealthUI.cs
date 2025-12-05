using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Image _foregroundImage;
    [SerializeField] private Image _backgorundImage;
    [SerializeField] private float _smoothSpeed;
    private float _targetFill;



    
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

    private void Update()
    {
        if (_foregroundImage.fillAmount != _targetFill)
        {
            _foregroundImage.fillAmount = Mathf.Lerp(_foregroundImage.fillAmount, _targetFill, Time.deltaTime * _smoothSpeed);

        }
    }

    private void UpdateHealthBar(int currentHealth)
    {
        if (_playerHealth == null) return;

        _targetFill = (float)currentHealth / _playerHealth.MaxHealth;

    }

    private void HandlePlayerDeath()
    {

        Debug.Log("[PlayerHealthUI] Player Died!");
        _targetFill = 0f;   
    }

  
}
