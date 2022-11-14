using ObjectManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BarMagnet : Selectable_Ferromagnetic
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float _poleStrength;

    public float PoleStrength
    {
        get => _poleStrength;
        private set
        {
            _poleStrength = value;
            MagneticPole[] poles = transform.GetComponentsInChildren<MagneticPole>();
            foreach (MagneticPole pole in poles)
            {
                pole.SetAbsoluteStrength(_poleStrength);
            }
        } 
    }

    public override float MagneticField { get => PoleStrength / 15f; set => PoleStrength = value * 15; }

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
        PoleStrength = _poleStrength;
    }
}
