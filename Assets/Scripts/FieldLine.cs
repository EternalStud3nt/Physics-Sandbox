using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldLine : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float unitsPerSegment = 0.5f;

    private Vector3 offset;

    public void Initialize(MagneticPole startingPole)
    {
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, startingPole.transform.position);
        for (int i = 1; i < 150; i++)
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(i, transform.position + offset);
            Vector3 fieldDirection = FieldDetector.GetTotalField(transform.position + offset);
            Vector3 nextSegmentPos = transform.position + offset + fieldDirection.normalized * unitsPerSegment;
            offset = nextSegmentPos - transform.position;
        }
    }
}
