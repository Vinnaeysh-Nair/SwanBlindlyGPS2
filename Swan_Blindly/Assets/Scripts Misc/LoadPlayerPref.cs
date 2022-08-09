using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPlayerPref : MonoBehaviour
{
    [Header("General Setting")]
    [SerializeField] private bool canUse = false;
    [SerializeField] private MainMenuController mainMenuController;

    [Header("Volume Setting")]
    [SerializeField] private TextMeshProUGUI volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;

    [Header("Brightness Setting")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TextMeshProUGUI brightnessTextValue = null;

    [Header("Quality Setting")]
    [SerializeField] private TextMeshProUGUI qualityDropdown;

    [Header("Fullscreen Setting")]
    [SerializeField] private Toggle fullScreenToggle;

    [Header("Sensitivity Setting")]
    [SerializeField] private TextMeshProUGUI controllerSenTextValue = null;
    [SerializeField] private Slider controllerSenSlider = null;

/*    [Header("Invert Y Setting")]
    [SerializeField] private Toggle invertYToggle = null;*/

    private void Awake()
    {
        if (canUse)
        {
            if (PlayerPrefs.HasKey("masterVolume"))
            {
                float localVolume = PlayerPrefs.GetFloat("masterVolume");

                volumeTextValue.text = localVolume.ToString("0.0");
                volumeSlider.value = localVolume;
                AudioListener.volume = localVolume;
            }
            else
            {
                mainMenuController.ResetButton("Audio");
            }

            if (PlayerPrefs.HasKey("masterQuality"))
            {
                int localQuality = PlayerPrefs.GetInt("masterQuality");
                qualityDropdown.text = localQuality.ToString();
                QualitySettings.SetQualityLevel(localQuality);
            }

            if(PlayerPrefs.HasKey("masterFullscreen"))
            {
                int localFullScreen = PlayerPrefs.GetInt("MasterFullscreen");

                if (localFullScreen == 1)
                {
                    Screen.fullScreen = true;
                    fullScreenToggle.isOn = false;
                }
                else
                {
                    Screen.fullScreen = false;
                    fullScreenToggle.isOn = false;
                }
            }

            if(PlayerPrefs.HasKey("masterBrightness"))
            {
                float localBrightness = PlayerPrefs.GetFloat("masterBrightness");

                brightnessTextValue.text = localBrightness.ToString("0,0");
                brightnessSlider.value = localBrightness;
                //change brightness here
            }

            if(PlayerPrefs.HasKey("masterSen"))
            {
                float localSensitivity = PlayerPrefs.GetFloat("masterSen");

                controllerSenTextValue.text = localSensitivity.ToString("0");
                controllerSenSlider.value = localSensitivity;
                mainMenuController.mainSens = Mathf.RoundToInt(localSensitivity);
            }
/*
            if (PlayerPrefs.HasKey("masterInvertY"))
            {
                if(PlayerPrefs.GetInt("masterInvertY") == 1)
                {
                    invertYToggle.isOn = true;
                }
                else
                {
                    invertYToggle.isOn = false;
                }
            }*/
        }
    }
}
