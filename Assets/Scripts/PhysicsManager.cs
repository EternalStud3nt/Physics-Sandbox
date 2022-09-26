using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoBehaviour
{
    public static PhysicsManager Instance { get; private set; }
    public static List<MagneticPole> NorthPoles { get; private set; } = new List<MagneticPole>();
    public static List<MagneticPole> SouthPoles { get; private set; } = new List<MagneticPole>();


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

    }
}
