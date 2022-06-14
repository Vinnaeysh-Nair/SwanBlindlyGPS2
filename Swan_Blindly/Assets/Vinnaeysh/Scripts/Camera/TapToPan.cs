using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToPan : MonoBehaviour
{
    float firstTapTime;
    [SerializeField] float durationBetweenTaps;
    [SerializeField] float camSpeed;
    Camera cam;
    Vector3 camTargetPosition;

    bool isMoving;
    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //DoubleTapLogic
            if (Time.time - firstTapTime < durationBetweenTaps)
            {
                if (cam.orthographic)
                {
                    camTargetPosition = cam.ScreenToWorldPoint(Input.mousePosition);
                    isMoving = true;
                }
                else // perspective camera 
                {
                    Plane plane = new Plane(Vector3.forward, Vector3.zero);

                    //Ray that goes from camera towards the tap touched on the screen
                    Ray touchray = cam.ScreenPointToRay(Input.mousePosition);

                    //if touchray hit the plane get the distance of the ray
                    if (plane.Raycast(touchray, out float touchDist))
                    {
                        Ray camFocusRay = new Ray(cam.transform.position, cam.transform.forward);

                        if (plane.Raycast(camFocusRay, out float focusDist))
                        {
                            //Get where the ray hit the plane
                            Vector3 touchpos = touchray.GetPoint(touchDist);
                            Vector3 focuspos = camFocusRay.GetPoint(focusDist);

                            //Get the final position of the camera using the offset
                            camTargetPosition = cam.transform.position + touchpos - focuspos;
                            camTargetPosition.z = cam.transform.position.z;

                            isMoving = true;
                        }
                    }

                }
            }
            firstTapTime = Time.time;
        }

        if (isMoving)
        {
            MoveCamera();
        }
    }

    private void MoveCamera()
    {
        if (Vector3.Distance(cam.transform.position, camTargetPosition) < 0.001f)
        {
            isMoving = false;
            return;
        }

        //Movement code here
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, camTargetPosition, camSpeed * Time.deltaTime);
    }
}
