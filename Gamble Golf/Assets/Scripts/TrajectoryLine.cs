using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryLine : MonoBehaviour {
    
    public LineRenderer lineRenderer;
    
    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 startPoint, Vector3 endPoint) {
        lineRenderer.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        lineRenderer.SetPositions(points);
    }

    public void EndLine ()
    {
        lineRenderer.positionCount = 0;
    }

}
