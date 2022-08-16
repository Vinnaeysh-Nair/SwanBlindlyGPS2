using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject canvas;
    [SerializeField] GameObject playerCam;
    [SerializeField] GameObject NPCCam;
    public Rigidbody rb;
    
    public Animator animator;

    private Queue<string> sentences;    

    void Start()
    {
        sentences = new Queue<string>();
        NPCCam.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        canvas.SetActive(false);
        rb.constraints = RigidbodyConstraints.FreezePosition;
        playerCam.SetActive(false);
        NPCCam.SetActive(true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        canvas.SetActive(true);
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        playerCam.SetActive(true);
        NPCCam.SetActive(false);
    }    
}
