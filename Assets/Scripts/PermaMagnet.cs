using ObjectManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PermaMagnet : Selectable_Ferromagnetic
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float _poleStrength;
    [SerializeField] private VFX_ForceField _forceField;

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
            _forceField.SetRadius(1 + MagneticFieldAtOneMeter);
        } 
    }

    public override float MagneticFieldAtOneMeter { get => PoleStrength / 15f; set => PoleStrength = value * 15; }

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
