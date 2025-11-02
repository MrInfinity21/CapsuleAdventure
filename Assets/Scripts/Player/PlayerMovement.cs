using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using TMPro;
using UnityEngine.Rendering;


[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private InputSystem_Actions _inputActions;
    private CharacterController _characterControl;

    private Vector2 _moveInput;
    private Vector2 _lookInput;
    private Vector3 _charaVelocity;
    private bool _isJumpPressed;
    private bool _isSprinting;

    [Header("Movement Values")]
    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private float _sprintSpeed = 6f;
    [SerializeField] private float _jumpHeight = 1.5f;
    [SerializeField] private float _gravity = -9.81f;

    [Header("Camera Look")]
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private float mouseSensitivty = 2f;
    private float _xRotation;

    [Header("Sprint/Stamina")]
    [SerializeField] private float maxStamina = 100f;
    [SerializeField] private float staminaDrainRate = 25f;
    [SerializeField] private float staminaRegenRate = 15f;
    private float currentStamina;
    
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI staminaText;


    [Header("Melee Weapon")]
    [SerializeField] private PlayerMelee meleeAttack;
    private void Awake()
    {
        _characterControl = GetComponent<CharacterController>();
        _inputActions = new InputSystem_Actions();

        // My Player Movement
        _inputActions.Player.Move.performed += context => _moveInput = context.ReadValue<Vector2>();
        _inputActions.Player.Move.canceled += context => _moveInput = Vector2.zero;

        //My Camera Movement
        _inputActions.Player.Look.performed += context => _lookInput = context.ReadValue<Vector2>();
        _inputActions.Player.Look.canceled += context => _lookInput = Vector2.zero;

        //Jump
        _inputActions.Player.Jump.performed += context => _isJumpPressed = true;
        _inputActions.Player.Jump.canceled += context => _isJumpPressed = false;

        // Sprint (hold Shift)
        _inputActions.Player.Sprint.performed += ctx => SetSprinting(true);
        _inputActions.Player.Sprint.canceled += ctx => SetSprinting(false);


        // Attack button triggers the swing in melee script
        _inputActions.Player.Attack.performed += ctx => meleeAttack.Swing();
    }

    private void OnEnable() => _inputActions.Enable();
    private void OnDisable() => _inputActions.Disable();

    private void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
       Cursor.visible = false;

        currentStamina = maxStamina;
       
    }
    private void Update()
    {
        MoveCharacter();
        LookAround();
        HandleStamina();
    }

    private void MoveCharacter()
    {
        float currentSpeed = _isSprinting ? _sprintSpeed : _walkSpeed;
        Vector3 moveDirection = transform.right * _moveInput.x + transform.forward * _moveInput.y;
        Vector3 horizontalVelocity = moveDirection * currentSpeed;

        if (_characterControl.isGrounded)
        {
            if(_charaVelocity.y < 0)
            _charaVelocity.y = -2f;

            if (_isJumpPressed)
            {
                _charaVelocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            }
        }

        _charaVelocity.y += _gravity * Time.deltaTime;

        Vector3 finalVelocity = horizontalVelocity + _charaVelocity;
        _characterControl.Move(finalVelocity * Time.deltaTime);
    }

    private void LookAround()
    {
        float mouseX = _lookInput.x * mouseSensitivty;
        float mouseY = _lookInput.y * mouseSensitivty;

        // Rotate camera holder up/down
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -80f, 80f);
        cameraHolder.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        // Rotate player body L/R
        transform.Rotate(Vector3.up * mouseX);
    }   

    private void HandleStamina()
    {
        bool isMoving = _moveInput.magnitude > 0.1f;

        if(_isSprinting && currentStamina > 0f)
        {
            currentStamina -= staminaDrainRate * Time.deltaTime;
            if(currentStamina <= 0f)
            {
                currentStamina = 0f;
                SetSprinting(false);
            }
        }

        if(!_isSprinting && currentStamina > maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Min(currentStamina, maxStamina);
        }
        

        if (staminaText != null)
            staminaText.text = $"Stamina: {Mathf.RoundToInt(currentStamina)}/{Mathf.RoundToInt(maxStamina)}";       
    }

    private void SetSprinting(bool sprinting)
    {
        bool isMoving = _moveInput.magnitude > 0.1f;

        if (sprinting && (!isMoving || currentStamina <= 0f))
            sprinting = false;

        _isSprinting = sprinting;
    }

    public float GetCurrentStamina() => currentStamina;
    public float GetMaxStamina() => maxStamina;

    public void RestoreStamina(float amount)
    {
        if (amount <= 0f) return;

        currentStamina = Mathf.Min(currentStamina + amount, maxStamina);
    }
   
}
