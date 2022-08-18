using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainmenuBG : MonoBehaviour
{
    [SerializeField] private AudioClip menuMusic;

    // Start is called before the first frame update
    void Awake()
    {
        AudioManager.Instance.PlayMusicWithCrossFade(menuMusic);
    }
}

    
