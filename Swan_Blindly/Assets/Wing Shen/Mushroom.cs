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
    //public GameObject Canvas;
    public int num;
    public Dialogue dialogue;

    void Start()
    {
        collider = GetComponent<Collider>();
        //Dialogue.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {      
        if(other.CompareTag("Player"))
        {
            if(num == 1)
            {
                //Canvas.SetActive(false);
                //Dialogue.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                NameBox.GetComponent<Text>().text = "Tutorial 1";
                TextBox.GetComponent<Text>().text = "Swipe and hold on the left side of the screen to move the character.";
            }
            
            if(num == 2)
            {
                //Canvas.SetActive(false);
                Dialogue.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                NameBox.GetComponent<Text>().text = "Tutorial 2";
                TextBox.GetComponent<Text>().text = "Swipe and hold on the right side of the screen to move the camera.";
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Dialogue.SetActive(false);
            //Canvas.SetActive(true);
        }
    }
}
