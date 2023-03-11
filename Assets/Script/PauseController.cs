using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    PlayerAction playerAction;
    private bool isPausing = false;

    [SerializeField] private GameObject pauseUI;
    [SerializeField] private Button resumeButton;

    private void Awake()
    {
        playerAction = new PlayerAction();
        resumeButton.onClick.AddListener(onResumeButtonPress);
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnEnable()
    {
        playerAction.Enable();
        playerAction.UI.Cancel.performed += onPauseButton;

    }

    private void OnDisable()
    {
        playerAction.UI.Cancel.performed -= onPauseButton;
    }

    public void onResumeButtonPress()
    {
        pausing();
    }

    public void onPauseButton(InputAction.CallbackContext obj)
    {
        pausing();
    }

    public void pausing()
    {
        if (!isPausing)
        {
           Time.timeScale = 0;
            pauseUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1;
            pauseUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        isPausing = !isPausing;
    }


}
