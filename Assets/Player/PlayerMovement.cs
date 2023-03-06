using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
     PlayerAction playerAction;

    [SerializeField] private float moveSpeed;

    Vector2 moveVector;
    CharacterController characterController;
    // Start is called before the first frame update
    private void Awake()
    {
        playerAction = new PlayerAction();
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        playerAction.Enable();
        playerAction.Player.Move.performed += OnMovementPerformed;
        playerAction.Player.Move.canceled += OnMovementCancle;
    }

    private void OnMovementCancle(InputAction.CallbackContext obj)
    {
        moveVector = Vector2.zero;
    }

    private void OnDisable()
    {
        playerAction.Disable();
        playerAction.Player.Move.performed -= OnMovementPerformed;
        playerAction.Player.Move.canceled -= OnMovementCancle;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        characterController.Move((transform.right * moveVector.x + transform.forward * moveVector.y) * moveSpeed * Time.deltaTime);
    }
}
