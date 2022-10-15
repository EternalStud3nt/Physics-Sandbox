using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    public static PhysicsManager Instance { get; private set; }
    public static List<MagneticPole> MagneticPoles { get; private set; } = new List<MagneticPole>();
    public static List<FieldDetector> FieldDetectors { get; private set; } = new List<FieldDetector>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public static void RegisterMagneticPole(MagneticPole pole)
    {
        MagneticPoles.Add(pole);
    }

    public static void UnRegisterMagneticPole(MagneticPole pole)
    {
        MagneticPoles.Remove(pole);
    }

    public static void RegisterFieldDetector(FieldDetector fieldDetector)
    {
        FieldDetectors.Add(fieldDetector);
    }

    public static void UnregisterFieldDetector(FieldDetector fieldDetector)
    {
        FieldDetectors.Remove(fieldDetector);
    }
}
