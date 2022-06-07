using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float radius = 3f;
    [SerializeField] private Transform player;
    [SerializeField] private KeyCode interactionButton;
    private bool canInteract = false;

    public virtual void pickUpItem()
    {
        Debug.Log("Item pick up ");
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance <= radius)
        {
            if (!canInteract)
                canInteract = true;
        }
        else  
        {
            if (canInteract)
                canInteract = false;
        }
        
        if (Input.GetKeyDown(interactionButton)&&canInteract)
        {
            pickUpItem();
        }
    }

    //this is to see the radius for better visualisation
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
