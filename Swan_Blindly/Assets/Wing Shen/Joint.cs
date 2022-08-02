using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint : MonoBehaviour
{
    public Rigidbody rb;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.name == "Cube")
                {
                    GetComponent<FixedJoint>().connectedBody = null;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "MC_01")
        {
            GetComponent<FixedJoint>().connectedBody = rb;
        }
    }
}
