using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ComputerManager : MonoBehaviour
{
    public static Action OnAnimationFinish;
    private CinemachineBrain cinemachineBrain => Camera.main.GetComponent<CinemachineBrain>();
    [SerializeField] private float offsetTime;

    [SerializeField] private GameObject questionButton;
    [SerializeField] private GameObject exitButton;

    public void PCinteract()
    {
        StartCoroutine(pcWait());

        GlobalInputController.Instance.playerAction.Player.Disable();
    }

    IEnumerator pcWait()
    {
        GlobalCameraController.Instance.CallCam("PCcam");

        yield return new WaitForSeconds(cinemachineBrain.m_CustomBlends.m_CustomBlends[0].m_Blend.m_Time + offsetTime);

        Cursor.lockState = CursorLockMode.None;

        exitButton.SetActive(true);
        questionButton.SetActive(true);
    }
}
