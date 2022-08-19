using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [Header("Loading Screen")]
    public static SceneLoader Instance;
    [SerializeField] public GameObject loaderCanvas;
    [SerializeField] public Image loadingBar;
    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    //public Animator transition;
    public float transitionTime = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        loaderCanvas.SetActive(true);
        scenesToLoad.Add(SceneManager.LoadSceneAsync("MainLevel"));
        StartCoroutine(LoadingScene());
        //StartCoroutine(LoadingProgress());
    }

    public void Cutscene()
    {
        loaderCanvas.SetActive(true);
        scenesToLoad.Add(SceneManager.LoadSceneAsync("Cutscenes 2"));
        StartCoroutine(LoadingScene());
    }

    IEnumerator LoadingScene()
    {
        //transition.SetTrigger("Start");

        float totalProgress = 0;
        for (int i = 0; i < scenesToLoad.Count; ++i)
        {
            while (!scenesToLoad[i].isDone)
            {
                totalProgress += scenesToLoad[i].progress;
                loadingBar.fillAmount = totalProgress / scenesToLoad.Count;
                yield return null;
            }
        }

        yield return new WaitForSeconds(transitionTime);
    }

    IEnumerator LoadingProgress()
    {
        float totalProgress = 0;
        for (int i = 0; i < scenesToLoad.Count; ++i)
        {
            while (!scenesToLoad[i].isDone)
            {
                totalProgress += scenesToLoad[i].progress;
                loadingBar.fillAmount = totalProgress / scenesToLoad.Count;
                yield return null;
            }
        }
    }
}
