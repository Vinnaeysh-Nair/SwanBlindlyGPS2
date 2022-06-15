using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceScript : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject ChoiceYes;
    public GameObject ChoiceNo;
    public int ChoiceMade;

    public void Yes()
    {
        TextBox.GetComponent<Text>().text = "Thank you.";
        ChoiceMade = 1;
    }

    public void No()
    {
        TextBox.GetComponent<Text>().text = "Please find for me.";
        ChoiceMade = 2;
    }

    void Update()
    {
        if(ChoiceMade >= 1)
        {
            ChoiceYes.SetActive(false);
            ChoiceNo.SetActive(false);
        }
    }
}
