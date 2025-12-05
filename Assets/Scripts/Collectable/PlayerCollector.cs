using UnityEngine;

public class PlayerCollector : MonoBehaviour, ICollector
{
  

    public void OnCollect(ICollectable collectable)
    {
        ScoreManager.Instance.AddScore(collectable.PointValue);
        collectable.Collect(gameObject);

        Debug.Log($"Collected item worth {collectable.PointValue}");
    }
}
