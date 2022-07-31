using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove3rdPerson : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public bool isMoving = false;
    public Transform Orientation;
    public float airMultiplier;


    [Header("Ground")]
    public float PlayerHeight;
    public LayerMask WhatIsGround;
    bool isgrounded;

    private Rigidbody rb;
    private Animator PlayerAnim;
    private Joystick_Controls joystickControls;
    float InputHorizontal;
    float InputVertical;
    Vector3 moveDir;



    void Start()
    {
        PlayerAnim = transform.GetChild(0).GetComponent<Animator>();
        joystickControls = GameObject.Find("JoystickBg").GetComponent<Joystick_Controls>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        //GroundCheck
        isgrounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 0.5f + 0.2f, WhatIsGround);

        KeyInput();
        SpeedControl();
        //Applying ground drag when player on the ground
        if (isgrounded)
        {
            rb.drag = groundDrag;
        }
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void KeyInput()
    {
        InputHorizontal = joystickControls.inputHorizontal();
        InputVertical = joystickControls.inputVertical();
    }

    private void PlayerMove()
    {
        //calculate move dir
        moveDir =  Orientation.forward  * InputVertical + Orientation.right * InputHorizontal;

        //On ground
        if (isgrounded)
        {
            rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
            isMoving = true;
        }
        //In Air
        else if (!isgrounded)
        {
            rb.AddForce(moveDir.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit the velocity when needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y , limitVel.z);
        }
    }
}
 