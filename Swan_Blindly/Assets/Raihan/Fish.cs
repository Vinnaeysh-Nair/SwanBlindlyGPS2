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

    private float spawnInterval;

    private void Start()
    {
        spawnInterval = Random.Range(4f, 8f);
        InvokeRepeating("Throw", 1.0f, spawnInterval);
    }

    private void Throw()
    {

        //Instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, spawnPoint.position, Quaternion.Euler(-90,0,180));

        //Get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();


        //Add force
        Vector3 forceToAdd = transform.forward * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);


    }

}
