using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebush : MonoBehaviour
{
    Collider collider;
    public GameObject firebush;
    public GameObject FirebushFire;
    public GameObject playerCam;
    public GameObject firebushCam;
    public GameObject canvas;
    public Rigidbody rb;

    void Start()
    {
        collider = GetComponent<Collider>();
        FirebushFire.SetActive(false);
        firebushCam.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "MC_01")
        {
            canvas.SetActive(false);
            rb.constraints = RigidbodyConstraints.FreezePosition;
            playerCam.SetActive(false);
            firebushCam.SetActive(true);
            FirebushFire.SetActive(true);
            StartCoroutine(burntFirebush());
        }
    }

    IEnumerator burntFirebush()
    {
        yield return new WaitForSeconds(2);
        firebush.SetActive(false);
        FirebushFire.SetActive(false);
        canvas.SetActive(true);
        rb.constraints = RigidbodyConstraints.None;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        firebushCam.SetActive(false);
        playerCam.SetActive(true);
    }
}
