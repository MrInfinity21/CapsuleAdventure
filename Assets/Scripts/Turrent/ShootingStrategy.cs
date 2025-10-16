using UnityEngine;

public abstract class ShootingStrategy : ScriptableObject
{
    public string ShootingStrategyName;

    public GameObject shootingObject;

    public abstract void Shoot(Transform _shootPoint);
    
}
