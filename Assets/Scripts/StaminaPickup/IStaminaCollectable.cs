using UnityEngine;

public interface IStaminaCollectable
{
    int StaminaAmount { get; }
    void Collect(GameObject collector);
}
