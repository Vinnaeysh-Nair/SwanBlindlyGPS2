using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] private float speed = 10f;
    private Vector3 point;


    private void Start()
    {
        point = player.transform.position;
        transform.LookAt(point);
    }
    public void Update()
    {
        CameraRotate();
    }

    public void CameraRotate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            transform.RotateAround(player.transform.position, Vector3.up, speed * Time.deltaTime);
        }
    }

}
