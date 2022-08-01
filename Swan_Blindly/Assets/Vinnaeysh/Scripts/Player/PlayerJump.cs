using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jumping")]
    private Rigidbody rb;
    private Animator playerAnim;

    [SerializeField] private float JumpForce = 5;
    private float distToGround = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jumping();
        }
        else
        {
            playerAnim.SetBool("Jump", false);
        }
    }
    
    public void Jumping()
    {
        if (isGrounded())
        {
            playerAnim.SetBool("Jump", true);
            rb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
        }
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.5f);
    }
}
