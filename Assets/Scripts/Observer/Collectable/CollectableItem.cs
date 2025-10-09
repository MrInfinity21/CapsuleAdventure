using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class CollectableItem : MonoBehaviour, ICollectable
{
    [SerializeField] private int _pointValue = 10;

    public int PointValue => _pointValue;

    // UnityEvents visible in Inspector
    public UnityEvent OnItemCollected;
    public UnityEvent<int> OnPointsAwarded;

    public void Collect(GameObject collector)
    {
        OnItemCollected?.Invoke();
        OnPointsAwarded?.Invoke(_pointValue);

        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ICollector>(out var collector))
        {
            collector.OnCollect(this);
        }
    }

    
}
