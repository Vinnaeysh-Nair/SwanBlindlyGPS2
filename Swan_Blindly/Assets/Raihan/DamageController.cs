using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private float bombDamage = 10.0f;

    [SerializeField] private HealthController _healthController = null;

    [SerializeField] private PostProcessingManager _postProcessingManager = null;

    [SerializeField] private AudioClip bombAudio = null;
    private bool playingAudio;
    private AudioSource bombAudioSource;

    public static bool collided = false;

    private void Start()
    {
        bombAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collided = true;
            Debug.Log(collided);
            _postProcessingManager.TakeDamage();
            bombAudioSource.PlayOneShot(bombAudio);
            _healthController.currentPlayerHealth -= bombDamage;
            _healthController.TakeDamage();
            gameObject.GetComponent<BoxCollider>().enabled = false;
            playingAudio = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collided = false;
            Debug.Log(collided);
        }
    }

    private void Update()
    {
        if (playingAudio)
        {
            if (!bombAudioSource.isPlaying)
            {
                gameObject.SetActive(false);
            }
        }
    }

    
}
