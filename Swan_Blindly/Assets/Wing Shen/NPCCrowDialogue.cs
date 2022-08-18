using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCrowDialogue : MonoBehaviour
{
    [SerializeField] GameObject playerCam;
    [SerializeField] GameObject NPCCam;
    [SerializeField] GameObject canvas;
    Collider collider;
    [SerializeField] GameObject Dialogue;
    [SerializeField] Dialogue dialogue;

    void Start()
    {
        collider = GetComponent<Collider>();
        NPCCam.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerCam.SetActive(false);
            NPCCam.SetActive(true);
            Dialogue.SetActive(true);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Dialogue.SetActive(false);
            playerCam.SetActive(true);
            NPCCam.SetActive(false);
        }
    }
}
