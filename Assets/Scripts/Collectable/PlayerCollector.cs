using UnityEngine;

public class PlayerCollector : MonoBehaviour, ICollector
{
    private int _score = 0;

    public void OnCollect(ICollectable collectable)
    {
        _score += collectable.PointValue;
        collectable.Collect(gameObject);

        Debug.Log($"Collected item worth {collectable.PointValue}");
    }
}
