using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    [Header("PickUp and Drop")]
    [SerializeField] private float Range = 5f;

    private void Update()
    {
        PickUp();    
    }
    void PickUp()
    {
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * Range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * Range));

        if (Physics.Raycast(theRay, out RaycastHit hit, Range))
        { 
            if (hit.transform.tag == "PickUpable")
            {
                Debug.Log("Ive hit a moveable object");
            }
            }
        }
    }


