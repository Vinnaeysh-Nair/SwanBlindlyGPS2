using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThirdPersonCam : MonoBehaviour
{
    [Header("Components needed")]
    public float RotationSpeed;
    public Transform orientation;
    public Transform Player;
    public Transform PlayerBody;
    public Rigidbody Rb;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerCamOrientation();
    }

    public void PlayerCamOrientation()
    {
        //This is to calculate the difference from the player and Cam and find the front facing direction
        Vector3 viewDir = Player.position - new Vector3(transform.position.x, Player.position.y, transform.position.z);
        //Setting the empty object "Orientation" created earlier to the viewDir created above
        orientation.forward = viewDir.normalized;

        //rotate player object
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        Vector3 inputDir = -1f * orientation.forward * inputVertical  + -1f * orientation.right * inputHorizontal;

        if (inputDir != Vector3.zero)
        {
            PlayerBody.forward = Vector3.Slerp(PlayerBody.forward, inputDir.normalized, Time.deltaTime * RotationSpeed);
        }
    }
}
