using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebush : MonoBehaviour
{
    //[SerializeField] private string PlayerTag = "Player";
    Collider collider;
    public GameObject firebush;
    public GameObject FirebushFire;
    //private CharacterController Controller;

    void Start()
    {
        //Controller = GameObject.FindGameObjectWithTag(PlayerTag).GetComponent<CharacterController>();
        collider = GetComponent<Collider>();
        FirebushFire.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "MainCharacter")
        {
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
