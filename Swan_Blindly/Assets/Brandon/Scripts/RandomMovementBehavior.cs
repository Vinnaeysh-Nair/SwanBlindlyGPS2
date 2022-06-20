using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovementBehavior : MonoBehaviour
{
    public float movementSpeed = 20f;
    public float rotationSpeed = 100f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    Rigidbody rb;
   // Animator anim;

    // Start is called before the first frame update
    void Start()
    {
       // anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWandering == false)
        {
             StartCoroutine(walkAround());
        }

        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
        }
        if(isWalking == true)
        {
            rb.AddForce(transform.forward * movementSpeed);
            //anim.SetBool("Walk", true);
        }
        if (isWalking == false)
        {
            //anim.SetBool("Walk", false);
        }
    }

    IEnumerator walkAround()
    {
        int rotationTime = Random.Range(1, 2);
        int rotationWait = Random.Range(1, 3);
        int rotationDir = Random.Range(0, 2);
        int walkTime = Random.Range(1, 2);
        int walkWait = Random.Range(2, 3);

        isWandering = true;

        Debug.Log(rotationDir);

        yield return new WaitForSeconds(walkWait);
        isWalking = true;

        yield return new WaitForSeconds(walkTime);
        isWalking = false;

        yield return new WaitForSeconds(rotationWait);
        if (rotationDir == 0)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
        }
        if (rotationDir == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
        }

        isWandering = false;
    }
}
