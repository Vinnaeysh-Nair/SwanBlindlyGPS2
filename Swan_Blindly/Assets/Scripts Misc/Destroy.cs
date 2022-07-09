using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject gameObj;
    void Start()
    {
        Destroy(gameObj, 5);
    }


    
}
