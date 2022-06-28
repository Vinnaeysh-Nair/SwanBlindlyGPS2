using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawProjection : MonoBehaviour
{
    Throwing throwingController;
    LineRenderer lineRenderer;

    //Number of points in the line
    public int numPoints = 50;

    //Distance between those points in the line
    public float timeBetweenPoints = 0.1f;

    //The physics layer that will cause the line to stop being drawn
    public LayerMask CollidableLayers;


    public void Start()
    {
        throwingController = GetComponent<Throwing>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void Update()
    {
       // RenderLine();
    }

    public void RenderLine()
    {

        lineRenderer.positionCount = numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = throwingController.throwingPoint.position;
        Vector3 startingVelocity = throwingController.cam.transform.forward * throwingController.throwForce + transform.up * throwingController.throwUpwardForce;
        for (float t = 0; t < numPoints; t += timeBetweenPoints)
        {
            Vector3 newPoint = startingPosition + t * startingVelocity;
            newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y / 2f * t * t;
            points.Add(newPoint);

            if (Physics.OverlapSphere(newPoint, 0.2f, CollidableLayers).Length > 0)
            {
                lineRenderer.positionCount = points.Count;
                break;
            }
        }

        lineRenderer.SetPositions(points.ToArray());
    }
}
