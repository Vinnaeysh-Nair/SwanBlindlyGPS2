using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    [SerializeField] private bool isGrounded;
    private CharacterController cr;
    // Start is called before the first frame update
    void Start()
    {
        cr = GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Jumping()
    {
        if (isGrounded)
        {
            //cr.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);
        }

    }

}
