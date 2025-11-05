using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMelee : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private Animator _animator;

    [Header("Attack Settings")]
    [SerializeField] private float _attackDistance = 3f;
    [SerializeField] private float _attackDelay = 0.3f;
    [SerializeField] private float _attackCooldown = 0.7f;
    [SerializeField] private int _attackDamage = 1;
    [SerializeField] private LayerMask _attackLayer;

    private bool _isAttacking = false;
    private bool _canAttack = true;

    public void Start()
    {
        if(_playerCamera == null)
            _playerCamera = Camera.main;
        
    }

    public void Swing()
    {
        if (!_canAttack || _isAttacking) return;
        StartCoroutine(PerformAttack());
    }

    private IEnumerator PerformAttack()
    {
        _canAttack = false;
        _isAttacking= true;

        if (_animator != null)
            _animator.SetTrigger("Attack");


        yield return new WaitForSeconds(_attackDelay);
        AttackRaycast();

        yield return new WaitForSeconds(_attackCooldown);
        _isAttacking = false;
        _canAttack = true;
    }

    private void AttackRaycast()
    {
        if(Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, out RaycastHit hit, _attackDistance, _attackLayer))
        {

            var damageable = hit.collider.GetComponent<IDamageable>();
            if(damageable != null )
            {
                damageable.TakeDamage(_attackDamage);
            }

            
        }
    }

}
