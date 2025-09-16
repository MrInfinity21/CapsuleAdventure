using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private InputSystem_Actions _inputActions;
    private CharacterController _characterControl;

    private Vector2 _moveInput;
    private Vector2 _lookInput;
    private Vector3 _charaVelocity;

    [Header("Movement Values")]
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _jumpHeitght = 1.5f;
    [SerializeField] private float _gravity = -9.81f;

    private void Awake()
    {
        _characterControl = GetComponent<CharacterController>();
        _inputActions = new InputSystem_Actions();

        // My Player Movement
        _inputActions.Player.Move.performed += context => _moveInput = context.ReadValue<Vector2>();
        _inputActions.Player.Move.canceled += context => _moveInput = Vector2.zero;

        
    }

    private void OnEnable() => _inputActions.Enable();
    private void OnDisable() => _inputActions.Disable();

    private void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        Vector3 moveDirection = transform.right * _moveInput.x + transform.forward * _moveInput.y;
        Vector3 horizontalVelocity = moveDirection * _speed;

        if (_characterControl.isGrounded && _charaVelocity.y < 0)
        {
            _charaVelocity.y = -2f;
        }

        _charaVelocity.y += _gravity * Time.deltaTime;

        Vector3 finalVelocity = horizontalVelocity + _charaVelocity;
        _characterControl.Move(finalVelocity * Time.deltaTime);
    }
}
