using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBarUI : MonoBehaviour
{
    [SerializeField] private Image _foreground;
    private EnemyHealth _enemyHealth;

    public void Initialize(EnemyHealth enemyHealth)
    {
        _enemyHealth = enemyHealth;
        UpdateHealthBar(enemyHealth.CurrentHealth, enemyHealth.MaxHealth);
    }

    public void UpdateHealthBar(int current, int max)
    {
        _foreground.fillAmount = (float)current / max;
    }
}
