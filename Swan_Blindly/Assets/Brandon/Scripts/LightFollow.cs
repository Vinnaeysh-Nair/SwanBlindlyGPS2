using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour
{
    public GameObject objectInFocus;


    private void Update()
    {
        transform.LookAt(objectInFocus.transform);
    }
}
