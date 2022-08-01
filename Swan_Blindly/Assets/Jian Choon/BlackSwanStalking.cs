using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlackSwanStalking : MonoBehaviour
{
    [SerializeField] NavMeshAgent navAgent;
    [SerializeField] Transform playerToFollow;

    //use this for final version
/*    [Header("speed")]
    [SerializeField] int minSpeed = 1;
    [SerializeField] int maxSpeed = 5;*/
    
    [Range(1, 10)]
    [SerializeField] float speed = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            generateRandomSpeed();
            chaseTarget();
        }
        if(Input.GetKeyUp(KeyCode.G))
        {
            stopChasingTarget();
        }
    }

    void generateRandomSpeed()
    {
        //speed = Random.Range(minSpeed, maxSpeed);
        Debug.Log(speed);
        navAgent.speed = speed;
    }

    void chaseTarget()
    {
        navAgent.SetDestination(playerToFollow.position);
        navAgent.isStopped = false;
    }

    void stopChasingTarget()
    {
        navAgent.isStopped = true;
    }
}
