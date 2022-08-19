using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadCutscene2 : MonoBehaviour
{
    [Header("Scene Switch Components")]
    [SerializeField] private GameObject Cutscene2Loader;
    CapsuleCollider COll;

    // Start is called before the first frame update
    void Start()
    {
        COll = GetComponent<CapsuleCollider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Cutscene2Loader)
        {
            SceneManager.LoadScene("Cutscenes 2");
        }
    }
}
