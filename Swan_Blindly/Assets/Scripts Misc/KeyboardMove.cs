using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMove : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(vertical, 0, horizontal).normalized;

        if (direction.magnitude >= 0.1f)
        {
            //rotate player on y axis to point in direction
            float TargetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, Angle, 0f);

            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
