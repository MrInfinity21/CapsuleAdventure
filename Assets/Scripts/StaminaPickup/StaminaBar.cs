using UnityEngine;
using UnityEngine.UI;
public class StaminaBar : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Image foregroundImage;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private float smoothSpeed = 5f;
    private void Start()
    {
        if(_playerMovement == null)
            _playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    private void Update()
    {
        if (_playerMovement == null) return;

        float targetFill = _playerMovement.GetCurrentStamina() / _playerMovement.GetMaxStamina();
        foregroundImage.fillAmount = Mathf.Lerp(foregroundImage.fillAmount, targetFill, smoothSpeed * Time.deltaTime);

        Debug.Log($"[StaminaBar] Stamina: {_playerMovement.GetCurrentStamina():F1}/{_playerMovement.GetMaxStamina():F1} | Fill = {foregroundImage.fillAmount:F2}");
    }
}
