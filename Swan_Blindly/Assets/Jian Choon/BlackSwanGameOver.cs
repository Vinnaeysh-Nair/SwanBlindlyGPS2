using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSwanGameOver : MonoBehaviour
{
    CapsuleCollider capCollider;
    [SerializeField] Transform blackSwanTransform;
    bool inRange = false;

    
    private void Start()
    {
        capCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(blackSwanTransform.position, transform.position);
        if (distance <= 1)
        {
            inRange = true;
        }

        if (inRange)
        {
            killPlayer();
        }

        if(distance > 1)
        {
            inRange = false;
        }
    }

    void killPlayer()
    {
        Debug.Log("Game Over");
        Destroy(gameObject);
    }
}