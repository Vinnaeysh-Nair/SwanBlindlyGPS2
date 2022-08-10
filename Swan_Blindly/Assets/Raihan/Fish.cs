using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fish : MonoBehaviour
{
    [Header("Reference")]
    public Transform sParent;
    public Transform spawnPoint;
    public GameObject objectToThrow;


    [Header("Throwing")]
    public KeyCode throwkey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;


    private void Update()
    {
        if (Input.GetKeyDown(throwkey))
        {
            Throw();
        }

    }

    private void Throw()
    {

        //Instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, spawnPoint.position, Quaternion.Euler(-90,0,-90));

        //Get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();


        //Add force
        Vector3 forceToAdd = transform.forward * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);



    }
}
