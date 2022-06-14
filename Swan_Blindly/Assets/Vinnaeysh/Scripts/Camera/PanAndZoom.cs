using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanAndZoom : MonoBehaviour
{
    Camera cam;
    [SerializeField] float camSpeed;
    [SerializeField] float deadzone;
    [SerializeField] float sensitivity;

    // Start is called before the first frame update
    void Awake()
    {
        //cache your camera always
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        //Dragging one finger
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Debug.Log("Pan");
            Vector2 delta = Input.GetTouch(0).deltaPosition;

            float deltaMagnitude = delta.sqrMagnitude;
            float deadzoneSquared = deadzone * deadzone;

            Vector2 dragDirection = delta.normalized;

            if (delta != Vector2.zero && deltaMagnitude > deadzoneSquared)
            {
                cam.transform.Translate(-dragDirection * camSpeed * sensitivity * Time.deltaTime);
            }

        }
        else if (Input.touchCount == 2) //Pinch logic
        {
            Touch t1 = Input.GetTouch(0);
            Touch t2 = Input.GetTouch(1);
            if (cam.orthographic)
            {
                Vector2 firstTouchStartPos = t1.position - t1.deltaPosition;
                Vector2 secondTouchStartPos = t2.position - t2.deltaPosition;

                float startMagnitude = (firstTouchStartPos - secondTouchStartPos).sqrMagnitude;
                float currentMagnitude = (t1.position - t2.position).sqrMagnitude;

                float zoom = startMagnitude - currentMagnitude;
                float scaledZoom = zoom * 0.001f;

                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - zoom, 2f, 10f);

            }
            else //perspective
            {
                
                Vector2 firstTouchPos = RayPositionOnPlane(t1.position);
                Vector2 secondTouchPos = RayPositionOnPlane(t2.position);

                Vector2 firstTouchStartPos = RayPositionOnPlane(t1.position - t1.deltaPosition);
                Vector2 secondTouchStartPos = RayPositionOnPlane(t2.position - t2.deltaPosition);

                float zoom = Vector3.Distance(firstTouchPos, secondTouchPos) / Vector3.Distance(firstTouchStartPos, secondTouchStartPos) / Vector3.Distance(firstTouchStartPos, secondTouchStartPos);

                cam.transform.position = Vector3.LerpUnclamped(firstTouchStartPos, cam.transform.position, 1f/zoom);
            }
        }
    }

    Vector3 RayPositionOnPlane(Vector2 touchpos)
    {
        Plane plane = new Plane(Vector3.forward, Vector3.zero);

        //Ray that goes from camera towards the tap touched on the screen
        Ray touchray = cam.ScreenPointToRay(Input.mousePosition);

        //if touchray hit the plane get the distance of the ray
        if (plane.Raycast(touchray, out float touchDist))
        {
            return touchray.GetPoint(touchDist);
        }
        Debug.LogError("Ray did not hit the plane");
        return Vector3.zero;
    }
}
