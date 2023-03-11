using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private float rayRange;
    [SerializeField] private GameObject cam;
    private Interactable currentObject;

    private void OnEnable()
    {
        GlobalInputController.Instance.playerAction.Player.Interact.performed += OnInteractPerformed;
    }

    private void OnDisable()
    {
        GlobalInputController.Instance.playerAction.Player.Interact.performed -= OnInteractPerformed;
    }

    private void OnInteractPerformed(InputAction.CallbackContext obj)
    {
        currentObject?.InteractEvent.Invoke();
    }

    void Update()
    {
        RaycastHit _hit;
      
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, rayRange ))
        {
            if(_hit.transform.TryGetComponent(out Interactable _interactable))
            {
                if(currentObject != _interactable)
                {
                    currentObject = _interactable;
                    currentObject.LookEvent.Invoke();
                } 
            }
        }
    }
}
