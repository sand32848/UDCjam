using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    PlayerAction playerAction;

    [SerializeField] private float mouseSensitivity;
    [SerializeField]private CinemachineVirtualCamera vCam;

    private Vector2 lookVector;
    private Transform body;
    private float xRotation;

    private void Awake()
    {
        playerAction = new PlayerAction();
        body = GetComponent<Transform>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        playerAction.Enable();
        playerAction.Player.Look.performed += OnLookPerformed;
        playerAction.Player.Look.canceled += OnLookCancled;
    }

    private void OnDisable()
    {
        playerAction.Disable();
        playerAction.Player.Look.performed -= OnLookPerformed;
        playerAction.Player.Look.canceled -= OnLookCancled;
    }

    private void OnLookPerformed(InputAction.CallbackContext value)
    {
        lookVector = value.ReadValue<Vector2>();
    }

    private void OnLookCancled(InputAction.CallbackContext value)
    {
        lookVector = Vector2.zero;
    }

    private void Update()
    {
        float mouseX = lookVector.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookVector.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        vCam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        body.Rotate(Vector3.up * mouseX);
    }
}
