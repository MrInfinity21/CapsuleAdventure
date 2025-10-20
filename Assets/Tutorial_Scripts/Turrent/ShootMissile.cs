using System;
using UnityEngine;


public class ShootMissile : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private ShootingStrategy _defaultShootingStrategy;
    private ShootingStrategy _currentShootingStrategy;

    public event Action<string> OnShootingStrategyChanged;


    [Header("Missile Settings")]
    public float missileSpeed = 500f;
    public float missileLifeTime = 5f;


    void Start()
    {
        if (_defaultShootingStrategy) SetShootingStrategy(_defaultShootingStrategy);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentShootingStrategy?.Shoot(_shootPoint);
        }

    }

    public void SetShootingStrategy(ShootingStrategy newStrategy)
    {
        _currentShootingStrategy = newStrategy;
        Debug.Log($"Shooting strategy changed to: {_currentShootingStrategy.ShootingStrategyName}");
    }
}
