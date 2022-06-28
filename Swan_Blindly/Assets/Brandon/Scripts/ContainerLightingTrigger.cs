using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerLightingTrigger : MonoBehaviour
{
    public static bool containterTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            containterTrigger = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            containterTrigger = false;
        }
    }
    
}
