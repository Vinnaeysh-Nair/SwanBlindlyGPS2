using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatDisableJumpButton : MonoBehaviour
{
    BoxCollider boxCollider;
    [SerializeField] private GameObject jumpButton;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            jumpButton.SetActive(false);
        }
    }

/*    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            jumpButton.SetActive(true);
        }
    }*/
}