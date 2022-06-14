using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    [SerializeField] private float Xaxis;
    [SerializeField] private float Yaxis;
    [SerializeField] private float RotationSensitivity = 8f;
    [SerializeField] private float DistanceFromPlayer = 5f;
    [SerializeField] private Transform Player;
        
    // Update is called once per frame
    void Update()
    {
        CameraMove();
    }

    public void CameraMove()
    {
        Yaxis += Input.GetAxis("Mouse X")* RotationSensitivity;
        Xaxis -= Input.GetAxis("Mouse Y")* RotationSensitivity;

        //Vector3 to store Xaxis and Yaxis

        Vector3 targetRotation = new Vector3(Xaxis, Yaxis);
        transform.eulerAngles = targetRotation;

        transform.position = Player.position - transform.forward * DistanceFromPlayer;
    }
}
