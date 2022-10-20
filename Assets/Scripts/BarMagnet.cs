using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMagnet : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float poleStrength;
    private void Awake()
    {
        MagneticPole[] poles = transform.GetComponentsInChildren<MagneticPole>();
        foreach (MagneticPole pole in poles)
        {
            //pole.SetStrength(poleStrength);
        }
    }
}
