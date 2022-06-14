using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamRotate : MonoBehaviour
{
    [SerializeField] FixedTouchField touchField;
    [SerializeField] Camera Cam;
    [SerializeField] float CamAngle;
    [SerializeField] float CamSpeed = 0.2f;
    [SerializeField] Vector3 CamOffset;

    // Start is called before the first frame update
    void Start()
    {
        touchField = FindObjectOfType<FixedTouchField>();
        Cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        CamAngle += touchField.TouchDist.x * CamSpeed;

        Cam.transform.position = transform.position + Quaternion.AngleAxis(CamAngle, Vector3.up) * CamOffset;

        Cam.transform.rotation = Quaternion.LookRotation(transform.position + Vector3.up * 2f-Cam.transform.position, Vector3.up);
    }
}
