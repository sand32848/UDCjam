using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    private GlobalCameraController camController => Camera.main.GetComponent<GlobalCameraController>();

    [SerializeField] private Button startButton;
    [SerializeField] private GameObject player;
    [SerializeField] private CanvasGroup canvasGroup;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        startButton.onClick.AddListener(InitiateGame);
    }

    public void InitiateGame() 
    {

        player.SetActive(true);
        GlobalCameraController.Instance.CallCam("PlayerCam");

        canvasGroup.DOFade(0,1f);
    }
}
