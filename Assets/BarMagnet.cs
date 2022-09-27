using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMagnet : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;

    private void Awake()
    {
        MagneticPole[] poles = transform.GetComponentsInChildren<MagneticPole>();
        foreach (MagneticPole pole in poles)
        {
            pole.MultiplyPoleStrength(rigidBody.mass);
        }
    }
}
