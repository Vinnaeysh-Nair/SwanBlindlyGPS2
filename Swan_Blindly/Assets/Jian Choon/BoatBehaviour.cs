using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoatBehaviour : MonoBehaviour
{
    [Header("Object Reference")]
    [SerializeField] private NavMeshAgent boatAgent;
    [SerializeField] private Transform endPoint;
    [SerializeField] private GameObject fishSpawner;
    
    //use this for final version
    [Header("Speed")]
    [SerializeField] private int minSpeed = 1;
    [SerializeField] private int maxSpeed = 5;

    /*[Range(1, 10)]
    [SerializeField] float speed = 1;*/
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private GameObject jumpButton;

    private float boat_speedValue;
    private float sin01;

    void Update()
    {
        boat_speedValue += 0.5f * Time.deltaTime;
        sin01 = (Mathf.Sin(boat_speedValue) * 0.5f) + 0.5f;
        generateSpeed();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            jumpButton.SetActive(false);
            chaseTarget();
            fishSpawner.SetActive(true);

            other.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.SetParent(null);
        }
    }

    void generateSpeed()
    {
        boatAgent.speed = Mathf.Lerp(minSpeed, maxSpeed, sin01);
    }

    void chaseTarget()
    {
        boatAgent.SetDestination(endPoint.position);
        boatAgent.isStopped = false;
    }

    void stopChasingTarget()
    {
        boatAgent.isStopped = true;
    }
}
