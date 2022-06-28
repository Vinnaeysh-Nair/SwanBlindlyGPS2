using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mushroom : MonoBehaviour
{
    Collider collider;
    public GameObject Dialogue;
    public GameObject NameBox;
    public GameObject TextBox;
    public int num;
    public Dialogue dialogue;

    void Start()
    {
        collider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {      
        if(other.CompareTag("Player"))
        {
            if(num == 1)
            {
                Dialogue.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                NameBox.GetComponent<Text>().text = "Tutorial 1";
                TextBox.GetComponent<Text>().text = "Use the Joystick to move the character.";
            }
            
            if(num == 2)
            {
                Dialogue.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                NameBox.GetComponent<Text>().text = "Tutorial 2";
                TextBox.GetComponent<Text>().text = "Swipe and hold on the right side of the screen to move the camera.";
            }

            if(num == 3)
            {
                Dialogue.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                NameBox.GetComponent<Text>().text = "Tutorial 3";
                TextBox.GetComponent<Text>().text = "Press the jump button to jump.";
            }

            if(num == 4)
            {
                Dialogue.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                NameBox.GetComponent<Text>().text = "Tutorial 4";
                TextBox.GetComponent<Text>().text = "Go close to items to pick them up.";
            }

            if(num == 5)
            {
                Dialogue.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                NameBox.GetComponent<Text>().text = "Tutorial 5";
                TextBox.GetComponent<Text>().text = "";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Dialogue.SetActive(false);
        }
    }
}
