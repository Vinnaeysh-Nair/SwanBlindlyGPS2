using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlackSwanStalking : MonoBehaviour
{
    [SerializeField] NavMeshAgent navAgent;
    [SerializeField] Transform playerToFollow;

    //use this for final version
    [Header("Speed")]
    [SerializeField] int minSpeed = 1;
    [SerializeField] int maxSpeed = 5;

    /*[Range(1, 10)]
    [SerializeField] float speed = 1;*/
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private GameObject jumpButton;

    private float color_tValue;
    private float sin01;
    
    void Update()
    {
        color_tValue += 0.5f * Time.deltaTime;
        sin01 = (Mathf.Sin(color_tValue) * 0.5f) + 0.5f;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            jumpButton.SetActive(false);
            chaseTarget();
        }
    }

    void generateSpeed()
    {
        navAgent.speed = Mathf.Lerp(minSpeed, maxSpeed, sin01);
    }

    void chaseTarget()
    {
        generateSpeed();
        navAgent.SetDestination(playerToFollow.position);
        navAgent.isStopped = false;
    }

    void stopChasingTarget()
    {
        navAgent.isStopped = true;
    }
}
