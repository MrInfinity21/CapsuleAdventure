using UnityEngine;

public interface ICollectable 
{
    int PointValue { get; }
    void Collect(UnityEngine.GameObject collector);
}
