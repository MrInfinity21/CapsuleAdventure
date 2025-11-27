using UnityEngine;

public class BatHitbox : MonoBehaviour
{
    [Header("Debug Gizmos")]
    public bool showGizmos = true;
    public Color gizmoColor = Color.red;


    private int _damage;
    private bool _canDamage;
    private BoxCollider _boxCollider;

    private void Awake()
    {
       _boxCollider = GetComponent<BoxCollider>();
       _boxCollider.isTrigger = true;
       _boxCollider.enabled = false;
    
    }

    public void Activate(int damage)
    {
        _damage = damage;
        _canDamage = true;  
        _boxCollider.enabled = true;
    }

    public void Deactivate()
    {
        _canDamage = false;
        _boxCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_canDamage) return;

        IDamageable damageable = other.GetComponent<IDamageable>();
        if(damageable != null)
        {
            damageable.TakeDamage(_damage);
            Debug.Log("Bat Hit: " + other.name); 
        }
    }

    private void OnDrawGizmos()
    {
        if (!showGizmos) return;
        if (_boxCollider == null) _boxCollider = GetComponent<BoxCollider>();
        if (_boxCollider == null) return;

        Gizmos.color = gizmoColor;

        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawWireCube(_boxCollider.center, _boxCollider.size);    
    }
}
