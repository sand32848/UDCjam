using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    [SerializeField] private Button settingButton;
    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject settingWindow;

    AudioMixer masterMixer;

    private void Awake()
    {
        settingButton.onClick.AddListener(onSettingButton);
        returnButton.onClick.AddListener(onReturnButton);
    }

    public  void onSettingButton()
    {
        settingWindow.SetActive(true);
    }

    public void onReturnButton()
    {
        settingWindow.SetActive(false);
    }
}
