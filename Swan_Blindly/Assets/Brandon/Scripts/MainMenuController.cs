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
    [SerializeField] private Text volumeSlider = null;

    [Header("Levels to load")]
    public string newGameLevel;
    private string lvlToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;

    [SerializeField] private GameObject confirmationPrompt = null;

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

    public void setVolume(int volume)
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

    public IEnumerator ConfirmationDialog()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
