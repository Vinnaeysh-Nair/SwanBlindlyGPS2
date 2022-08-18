using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBG : MonoBehaviour
{
    [SerializeField] private AudioClip gameMusic;

    void Awake()
    {
        AudioManager.Instance.PlayMusicWithCrossFade(gameMusic);
    }
}
