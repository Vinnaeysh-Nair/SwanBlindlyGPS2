using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVol = 50f;

    [Header("Gameplay Settings")]
    [SerializeField] private TMP_Text sensValue = null;
    [SerializeField] private Slider sensSlider = null;
    [SerializeField] private int defaultSens = 3;
    public int mainSens = 3;

    [Header("Graphics Settings")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessValue = null;
    [SerializeField] private float defaultBrightness = 1;

    [Space(10)]
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle fullScreenToggle;

    private int _qualityLevel;
    private bool _isFullscreen;
    private float _brightnessLevel;

    [Header("Levels to load")]
    public string newGameLevel;
    private string lvlToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;

    [Header("Resolution Dropdown")]
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    [SerializeField] private GameObject confirmationPrompt = null;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void NewGameDialogueYes()
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void loadGameDialogueYes()
    {
        //Load Next scene
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            lvlToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(lvlToLoad);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }

    public void exitButton()
    {
        Application.Quit();
    }    

    public void setVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeValue.text = volume.ToString("0");
    }
    
    public void volumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        //show Propt
        StartCoroutine(ConfirmationDialog());
    }

    public void SetSensitivity (float sensitivity)
    {
        mainSens = Mathf.RoundToInt(sensitivity);
        sensValue.text = sensitivity.ToString("0");
    }

    public void GameplayApply()
    {
        PlayerPrefs.SetFloat("masterSens", mainSens);
        StartCoroutine(ConfirmationDialog());
    }

    public void SetBrightness(float brightness)
    {
        _brightnessLevel = brightness;
        brightnessValue.text = brightness.ToString("0.0");

    }

    public void SetFullscreen (bool isFullScreen)
    {
        _isFullscreen = isFullScreen;
    }

    public void SetQuality(int qualityIndex)
    {
        _qualityLevel = qualityIndex;
    }

    public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("MasterBrightness", _brightnessLevel);
        //change brightness with postFX

        PlayerPrefs.SetInt("MasterQualtiy", _qualityLevel);
        QualitySettings.SetQualityLevel(_qualityLevel);

        PlayerPrefs.SetInt("masterFullscreen", (_isFullscreen ? 1 : 0));
        Screen.fullScreen = _isFullscreen;

        StartCoroutine(ConfirmationDialog());
    }

    public void ResetButton(string MenuType)
    {
        if(MenuType == "Audio")
        {
            AudioListener.volume = defaultVol;
            volumeSlider.value = defaultVol;
            volumeValue.text = defaultVol.ToString("0");
            volumeApply();
        }

        if(MenuType == "Gameplay")
        {
            sensValue.text = defaultSens.ToString("0");
            sensSlider.value = defaultVol;
            mainSens = defaultSens;
            GameplayApply();
        }

        if (MenuType == "Graphics")
        {
            //Reset Brightness Value
            brightnessSlider.value = defaultBrightness;
            brightnessValue.text = defaultBrightness.ToString("0.0");

            qualityDropdown.value = 1;
            QualitySettings.SetQualityLevel(1);

            fullScreenToggle.isOn = false;
            Screen.fullScreen = false;

            Resolution currentResolution = Screen.currentResolution;
            Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
            resolutionDropdown.value = resolutions.Length;
            GraphicsApply();
        }
    }

    public IEnumerator ConfirmationDialog()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
