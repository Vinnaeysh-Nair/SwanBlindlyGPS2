using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mushroom : MonoBehaviour
{
    Collider collide;
    public GameObject Dialogue;
    public TextMeshProUGUI NameBox;
    public TextMeshProUGUI TextBox;
    public int num;
    public Dialogue dialogue;

    void Start()
    {
        collide = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {      
        if(other.CompareTag("Player"))
        {
            if(num == 1)
            {
                Dialogue.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                NameBox.text = "Tutorial 1";
                TextBox.text = "Use the Joystick to move the character.";
            }
            
            if(num == 2)
            {
                Dialogue.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                NameBox.text = "Tutorial 2";
                TextBox.text = "Swipe and hold on the right side of the screen to move the camera.";
            }

            if(num == 3)
            {
                Dialogue.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                NameBox.text = "Tutorial 3";
                TextBox.text = "Press the jump button to jump.";
            }

            if(num == 33)
            {
                Dialogue.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                NameBox.text = "Reminder";
                TextBox.text = "Beware of the water as it can affect your health.";
            }

            if(num == 4)
            {
                Dialogue.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                NameBox.text = "Tutorial 4";
                TextBox.text = "Collide with one of the box and click on it and choose to click on either of the options to attach or detach the box.";
            }

            if(num == 5)
            {
                Dialogue.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                NameBox.text = "Tutorial 5";
                TextBox.text = "Pickable items will be displayed in the UI inventory when collected, in order to use the items tap it in the UI.";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Dialogue.SetActive(false);
        }
    }
}
