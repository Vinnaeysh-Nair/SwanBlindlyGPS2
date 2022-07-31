using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jumping")]
    public Rigidbody rb;
    public bool isOnGround;
    public float JumpForce = 5;
    public float JumpCoolDownVal = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isOnGround = true;
    }

    void Update()
    {
        Jumping();
        StartCoroutine(JumpCoolDown());
    }

    void Jumping()
    { 
        if (Input.GetButtonDown("Jump") && isOnGround )
        {
            rb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
            isOnGround = true;
    }

    IEnumerator JumpCoolDown()
    {
        if (!isOnGround)
        {
            yield return new WaitForSeconds(JumpCoolDownVal);
            isOnGround = true;
        }
    }
}
