using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LOADGAME : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("MainLevel", LoadSceneMode.Single);
    }
}
