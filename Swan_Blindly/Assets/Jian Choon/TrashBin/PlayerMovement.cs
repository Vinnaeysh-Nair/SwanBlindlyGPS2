using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rB;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private KeyCode rightControl;
    [SerializeField] private KeyCode leftControl;
    
    void FixedUpdate()
    {
        if (Input.GetKey(rightControl))
        {
            rB.velocity = (transform.right * movementSpeed);
        }
        if(Input.GetKey(leftControl))
        {
            rB.velocity = (transform.right * -movementSpeed);
        }
    }
}
