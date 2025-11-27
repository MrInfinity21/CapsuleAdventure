using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMelee : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private BatHitbox _batHitBox;
    [SerializeField] private Animator _animator;

    [Header("Attack Settings")]
    [SerializeField] private float _attackDelay = 0.3f;
    [SerializeField] private float _activeTime = 0.2f;
    [SerializeField] private float _attackCooldown = 0.7f;
    [SerializeField] private int _attackDamage = 1;



    private bool _isAttacking;
    private bool _canAttack = true;

    public void Swing()
    {
        if (!_canAttack || _isAttacking) return;
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        _canAttack = false;
        _isAttacking= true;

        if (_animator != null)
            _animator.SetTrigger("Attack");


        yield return new WaitForSeconds(_attackDelay);
        
        _batHitBox.Activate(_attackDamage);

        yield return new WaitForSeconds(_activeTime);

        _batHitBox.Deactivate();

        yield return new WaitForSeconds(_attackCooldown);
        _isAttacking = false;
        _canAttack = true;
    }

}

