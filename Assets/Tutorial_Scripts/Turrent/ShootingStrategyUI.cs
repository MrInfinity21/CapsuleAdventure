using TMPro;
using UnityEngine;


public class ShootingStrategyUI : MonoBehaviour
{
    [SerializeField] private ShootMissile shooter;
    [SerializeField] private TMP_Text txtCurrentStrategy;

    void OnEnable()
    {
        shooter.OnShootingStrategyChanged += UpdateStrategyText;    
    }

    void OnDisable()
    {
        shooter.OnShootingStrategyChanged -= UpdateStrategyText;
    }

    private void UpdateStrategyText(string value)
    {
        txtCurrentStrategy.text = value;
    }
}
