using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMelee : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _meleeWeapon;

    [Header("Swing Settings")]
    [SerializeField] private float _swingAngle = 90f;
    [SerializeField] private float _swingSpeed = 10f;
    [SerializeField] private float _returnSpeed = 6f;
    

    private bool _isSwinging = false;
    private Quaternion _initialRotation;

    private void Start()
    {
        if (_meleeWeapon != null)
            _initialRotation = _meleeWeapon.localRotation;

        else
            Debug.LogError("Weapon is not Assigned in PlayerMelee");
    }

    public void Swing()
    {
    
        if (_isSwinging && _meleeWeapon != null)
            StartCoroutine(SwingWeapon());
    }

    private IEnumerator SwingWeapon()
    {
        _isSwinging = true;

        Quaternion targetRotation = _initialRotation * Quaternion.Euler(0, -_swingAngle, 0);
        float time = 0f;

        // Swing forward
        while (time < 1f)
        {
            time += Time.deltaTime * _swingSpeed;
            _meleeWeapon.localRotation = Quaternion.Slerp(_initialRotation, targetRotation, time);
            yield return null;
        }

        // Return back
        time = 0f;
        while(time < 1f)
        {
            time += Time.deltaTime * _returnSpeed;
            _meleeWeapon.localRotation = Quaternion.Slerp(targetRotation, _initialRotation, time);
            yield return null;
        }

        _meleeWeapon.localRotation = _initialRotation;
        _isSwinging = false;
    }


}
