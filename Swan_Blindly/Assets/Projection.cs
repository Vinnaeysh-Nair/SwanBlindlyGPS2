using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projection : MonoBehaviour
{
    Aiming throwingController;
    LineRenderer lineRenderer;

    public int numPoints = 20;
    public float timeBetweenPoints = 0.1f;
    public LayerMask CollidableLayers;

    void Start()
    {
        throwingController = GetComponent<Aiming>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
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
