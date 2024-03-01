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

    private bool isMovementPressed = false;
    // Start is called before the first frame update
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        
        _playerInput.CharacterController.Move.started += onMovementInput;
        _playerInput.CharacterController.Move.canceled += onMovementInput;
        _playerInput.CharacterController.Move.performed += onMovementInput;
        
    }

    private void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        isMovementPressed = currentMovementInput.x != 0;
    }

    // Update is called once per frame
    private void Update()
    {
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
