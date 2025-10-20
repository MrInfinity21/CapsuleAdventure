using UnityEngine;

public interface IHealthCollectable
{
    int HealthAmount { get; }
    void Collect(GameObject collector);
}
