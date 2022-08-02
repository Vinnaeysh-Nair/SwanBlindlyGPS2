using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float radius = 3f;
    [SerializeField] private Transform player;

    public virtual void pickUpItem()
    {
        //Debug.Log("Item picked up");
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if(distance <= radius)
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