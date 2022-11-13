using ObjectManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BarMagnet : Selectable_Ferromagnetic
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float poleStrength;

    public override float MagneticField { get => poleStrength; set => poleStrength = value; }

    public override void OnDeselection()
    {
        rigidBody.isKinematic = false;
    }

    public override void OnSelection()
    {
        rigidBody.isKinematic = true;
    }

    private void Awake()
    {
        MagneticPole[] poles = transform.GetComponentsInChildren<MagneticPole>();
        foreach (MagneticPole pole in poles)
        {
            pole.SetAbsoluteStrength(poleStrength);
        }
    }
}
