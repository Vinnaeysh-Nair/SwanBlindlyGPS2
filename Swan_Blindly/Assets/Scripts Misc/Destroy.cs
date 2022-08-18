using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject gameObj;
    private GameObject player;

    void Start()
    {
        Destroy(gameObj, 3);
        player = GameObject.Find("MC_01");
    }

    private void Update()
    {
        transform.LookAt(player.transform.position, Vector3.forward);
        //, Vector3.up
    }

}
