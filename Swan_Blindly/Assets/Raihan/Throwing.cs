using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    [Header("Reference")]
    public Transform cam;
    public Transform throwingPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwkey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    public GameObject mainCamera;
    public GameObject aimCamera;

    bool readyToThrow;

    private LineRenderer line;

    public void Start()
    {
        readyToThrow = true;
        line = GetComponent<LineRenderer>();
    }

    public void Update()
    {
        //Aiming();
    }

    public void Aiming()
    {
        if (readyToThrow && totalThrows > 0 && !aimCamera.activeInHierarchy)
        {
            line.enabled = true;
            mainCamera.SetActive(false);
            aimCamera.SetActive(true);
        }
        if (readyToThrow && totalThrows > 0 && !mainCamera.activeInHierarchy)
        {
            Throw();
            mainCamera.SetActive(true);
            aimCamera.SetActive(false);
        }
    }

    public void Throw()
    {
        readyToThrow = false;
        line.enabled = false;

        //Instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, throwingPoint.position, cam.rotation);

        //Get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        //Calculate direction

        /*Vector3 forceDirection = cam.transform.forward;
        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point = attackPoint.position).normalized;
        }*/


        //Add force
        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        //ImplementCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    public void ResetThrow()
    {
        readyToThrow = true;
    }
}
