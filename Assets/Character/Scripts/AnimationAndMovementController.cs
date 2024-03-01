using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationAndMovementController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private CharacterController _characterController;
    private Animator _animator;
    
    private Vector2 currentMovementInput;
    private Vector2 currentMovement;
    
    private int isRunningHash;
    private int isRunningBackHash;

    private bool isMovementPressed;
    private bool isMovementBack;
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        
        isRunningHash = Animator.StringToHash("isRunning");
        isRunningBackHash = Animator.StringToHash("isRunningBack");
        
        _playerInput.CharacterController.Move.started += onMovementInput;
        _playerInput.CharacterController.Move.canceled += onMovementInput;
        _playerInput.CharacterController.Move.performed += onMovementInput;
        
    }

    private void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        isMovementPressed = currentMovementInput.x != 0;
        isMovementBack = currentMovement.x < 0;
        
    }
    
    void handleAnimation()
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
    private void Update()
    {
        handleAnimation();
        _characterController.Move(currentMovement * Time.deltaTime);
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
