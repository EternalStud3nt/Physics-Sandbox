using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMagnet : MonoBehaviour
{
    [SerializeField] private float poleStrength = 50;

    private void Start()
    {
        MagneticPole[] poles = transform.GetComponentsInChildren<MagneticPole>();
        foreach (MagneticPole pole in poles)
        {
            pole.SetPoleStrength(poleStrength);
        }
    }
}
