using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FieldDetector 
{
    public static Vector3 GetTotalField(Vector3 point)
    {
        Vector3 totalField = new();
        int totalPoles = PhysicsManager.MagneticPoles.Count;
        foreach (MagneticPole pole in PhysicsManager.MagneticPoles)
        {
            totalField += pole.CalculateFieldAtPoint(point);
        }
        return totalField;
    }

    public static Vector3 GetTotalField(Vector3 point, List<MagneticPole> ignoredPoles)
    {
        Vector3 totalField = new();
        int totalPoles = PhysicsManager.MagneticPoles.Count;
        foreach (MagneticPole pole in PhysicsManager.MagneticPoles)
        {
            if (ignoredPoles.Contains(pole)) continue;
            totalField += pole.CalculateFieldAtPoint(point);
        }
        return totalField;
    }
}
