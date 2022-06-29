using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerControl : MonoBehaviour
{
    //components
    private CharacterController cController;
    private Transform meshPlayer;
    private JoyStickManager JoyStickManager;
    private GameObject Player;


    //move
    [Header("PlayerControls")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;

    private float inputX;
    private float inputZ;
    private Vector3 v_movement;
    //private Vector3 JumpDirection = Vector3.zero;    
    private float gravity;

    void Start()
    {
        jumpSpeed = 0.63f;
        moveSpeed = 0.1f;
        gravity = 0.5f;
        Player = GameObject.FindGameObjectWithTag("Player");
        cController = Player.GetComponent<CharacterController>();
        JoyStickManager = GameObject.Find("JoystickBg").GetComponent<JoyStickManager>();
        meshPlayer = Player.transform.GetChild(0);

    }

    void Update()
    {
        inputX = JoyStickManager.inputHorizontal();
        inputZ = JoyStickManager.inputVertical();

    }

    private void FixedUpdate()
    {
        //gravity
        Gravity();

        // movement
        Movement();

        //mesh rotate
        Rotate();

    }

    public void Gravity()
    {
        if (cController.isGrounded)
        {
            v_movement.y = 0f;
        }
        else
        {
            v_movement.y -= gravity * Time.deltaTime;
           
        }
    }


    public void Movement()
    {
        v_movement = new Vector3(inputZ * moveSpeed, v_movement.y, -inputX * moveSpeed);
        cController.Move(v_movement);
    }

    public void Rotate()
    {
        if (inputX != 0 || inputZ != 0)
        {
            Vector3 lookDir = new Vector3(-v_movement.x, 0, -v_movement.z);
            meshPlayer.rotation = Quaternion.LookRotation(lookDir);
            cController.transform.Rotate(Vector3.up * inputX * (100f * Time.deltaTime));

        }
    }


    public void PlayerJump()
    {
        if (cController.isGrounded )
        {            
            v_movement.y = jumpSpeed;
            Debug.Log("Jumping");
        }

        v_movement.y -= gravity;
        cController.Move(v_movement * moveSpeed * Time.deltaTime);
    }
}
