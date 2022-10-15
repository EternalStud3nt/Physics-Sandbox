using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldDetector : MonoBehaviour
{
    public Vector3 Field { get; private set; }
    private void FixedUpdate()
    {
        Vector3 fieldSum = Vector3.zero;
        // Calculate the field each pole applies to the detector
        foreach (MagneticPole pole in PhysicsManager.MagneticPoles)
        {
            Vector3 appliedField = pole.CalculateFieldAtPoint(transform.position);
            fieldSum += appliedField;
        }
        Field = fieldSum;
    }
}
