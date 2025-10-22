using UnityEngine;

public interface ICollectable 
{
    int PointValue { get; }
    void Collect(UnityEngine.GameObject collector);
}

public interface ICollector
{
    void OnCollect(ICollectable collectable);
}

public interface IStaminaCollectable
{
    int StaminaAmount { get; }
    void Collect(GameObject collector);
}

public interface IHealthCollectable
{
    int HealthAmount { get; }
    void Collect(GameObject collector);
}

