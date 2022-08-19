using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadMainMenu : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}

