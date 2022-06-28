using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebush : MonoBehaviour
{
    Collider collider;
    //Collision collision;
    public GameObject firebush;
    public GameObject FirebushFire;

    void Start()
    {
        collider = GetComponent<Collider>();
        FirebushFire.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "MC with matchstick")
        {
            Debug.Log("Yes");
            FirebushFire.SetActive(true);
            StartCoroutine(burntFirebush());
        }
    }

    IEnumerator burntFirebush()
    {
        yield return new WaitForSeconds(2);
        firebush.SetActive(false);
        FirebushFire.SetActive(false);
    }
}
