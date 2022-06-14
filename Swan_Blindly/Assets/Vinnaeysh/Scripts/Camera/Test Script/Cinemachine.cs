using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cinemachine : MonoBehaviour
{

    [SerializeField] private float MouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;

    private float xRotation;
    // Update is called once per frame
    void Update()
    {
        float mouseX = 0;
        float mouseY = 0;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;
            mouseX = Input.GetTouch(0).deltaPosition.x;
            mouseY = Input.GetTouch(0).deltaPosition.y;
        }

        mouseX *= MouseSensitivity;
        mouseY *= MouseSensitivity;

        xRotation -= mouseY * Time.deltaTime;  
        xRotation = Mathf.Clamp(xRotation, -80, 80);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX * Time.deltaTime);
    }
}
