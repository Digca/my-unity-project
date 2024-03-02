using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationAndMovementController : MonoBehaviour
{
    [SerializeField] private GameObject _objectToRotate;
    [SerializeField] private float rotationSpeed;

    private PlayerInput _playerInput;
    private CharacterController _characterController;
    private Animator _animator;
    
    private Vector2 currentMovementInput;
    private Vector2 currentMovement;
    
    private int isRunningHash;
    private int isRunningBackHash;
    private int isJumpingHash;

    private bool isMovementPressed;
    private bool isMovementBack;

    [SerializeField] private bool isRotated = false;
    
    
    //gravity
    float groundedGravity = -.05f;
    float gravity = -1f;

    [SerializeField] private float moveSpeed;
    
    //jumping
    private bool isJumpPressed = false;
    private float initialJumpVelocity;
    [SerializeField] private float maxJumpHeight = 2.0f;
    [SerializeField] private float maxJumpTime = .75f;
    private bool isJumping = false;
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        
        isRunningHash = Animator.StringToHash("isRunning");
        isRunningBackHash = Animator.StringToHash("isRunningBack");
        isJumpingHash = Animator.StringToHash("isJumping");
        
        _playerInput.CharacterController.Move.started += onMovementInput;
        _playerInput.CharacterController.Move.canceled += onMovementInput;
        _playerInput.CharacterController.Move.performed += onMovementInput;
        
        _playerInput.CharacterController.Jump.started += onJump;
        _playerInput.CharacterController.Jump.canceled += onJump;

        setupJumpVariables();
    }
    
    private void setupJumpVariables()
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
        Debug.Log(initialJumpVelocity);
        Debug.Log(gravity);
    }

    private void onJump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
        Debug.Log(isJumpPressed);
    }
    
    private void handleJump()
    {
        if (!isJumping && _characterController.isGrounded && isJumpPressed)
        {
            _animator.SetBool(isJumpingHash, true);
            isJumping = true;
            currentMovement.y = initialJumpVelocity;
        } 
        else if (!isJumpPressed && isJumping && _characterController.isGrounded)
        {
            isJumping = false;
            _animator.SetBool(isJumpingHash, false);
        }
    }

    private void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x * moveSpeed;
        isMovementPressed = currentMovementInput.x != 0;
        if (!isRotated)
        {
            isMovementBack = currentMovement.x < 0;
        } else
        {
            isMovementBack = currentMovement.x < 0;
        }
        
    }
    
    private void handleAnimation()
    {
        bool isRunning = _animator.GetBool(isRunningHash);
        bool isRunningBack = _animator.GetBool(isRunningBackHash);

        if (isMovementPressed && !isMovementBack)
        {
            _animator.SetBool(isRunningHash, true); 
        }
        else if (isMovementPressed && isMovementBack)
        {
            _animator.SetBool(isRunningBackHash, true); 
        }
        if (!isMovementPressed && (isRunning || isRunningBack))
        {
            _animator.SetBool(isRunningHash, false);
            _animator.SetBool(isRunningBackHash, false);
        }
        
    }

    private void handleRotation()
    {
        
    }

    private void handleGravity()
    {
        if (_characterController.isGrounded)
        {
            currentMovement.y = groundedGravity;
        }
        else
        {
            currentMovement.y += gravity * Time.deltaTime;
        }
    }
    
    private void Update()
    {
        handleAnimation();
        _characterController.Move(currentMovement * Time.deltaTime);
        handleGravity();
        handleJump();
    }
    
    private void OnEnable()
    {
        _playerInput.CharacterController.Enable();
    }
    private void OnDisable()
    {
        _playerInput.CharacterController.Disable();
    }
}
