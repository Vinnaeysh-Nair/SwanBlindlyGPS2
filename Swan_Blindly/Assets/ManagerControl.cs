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
    private float inputX;
    private float inputZ;
    private Vector3 v_movement;
    [SerializeField] private float moveSpeed;
    private float gravity;

    void Start()
    {
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
        if (cController.isGrounded)
        {
            v_movement.y = 0f;
        }
        else 
        {
            v_movement.y -= gravity * Time.deltaTime;
        }

        // movement
        v_movement = new Vector3(inputZ* moveSpeed, v_movement.y, -inputX * moveSpeed);
        cController.Move(v_movement);

        //mesh rotate
        if (inputX != 0 || inputZ != 0)
        {
            Vector3 lookDir = new Vector3(-v_movement.x, 0, -v_movement.z);
            meshPlayer.rotation = Quaternion.LookRotation(lookDir);
        }
    }
}
