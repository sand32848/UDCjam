using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ComputerInterface : MonoBehaviour
{
    [SerializeField] private SpriteButton exitButton;
    [SerializeField] private SpriteButton questionButton;

    public static Action onQuestionButtonClick;

    private void OnEnable()
    {
        exitButton.onButtonClick += OnExitButtonClick;
        questionButton.onButtonClick += OnQuestionButtonClick;
    }

    private void OnDisable()
    {
        exitButton.onButtonClick -= OnExitButtonClick;
        questionButton.onButtonClick -= OnQuestionButtonClick;
    }

    public void OnExitButtonClick()
    {
        GlobalInputController.Instance.playerAction.Enable();
        GlobalCameraController.Instance.CallCam("PlayerCam");
        Cursor.lockState = CursorLockMode.Locked;

        questionButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    public void OnQuestionButtonClick()
    {
        onQuestionButtonClick?.Invoke();
    }
}
