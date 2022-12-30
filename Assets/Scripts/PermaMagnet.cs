using ObjectManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PermaMagnet : Selectable_Ferromagnetic
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float _poleStrength;
    [SerializeField] private FieldVisualizer fieldVisualizer;


    private MagneticPole[] _poles;

    public MagneticPole[] Poles
    {
        get
        {
            if (_poles == null)
            {
                _poles = transform.GetComponentsInChildren<MagneticPole>();
            }
            return _poles;
        }
    }

    private MagneticPole SouthPole
    {
        get
        {
            foreach (MagneticPole pole in Poles)
            {
                if(pole.Type == MagneticPole.PoleType.South)
                {
                    return pole;
                }
            }
            return Poles[0];
        }
    }

    public float PoleStrength
    {
        get => _poleStrength;
        private set
        {
            _poleStrength = value;
            foreach (MagneticPole pole in Poles)
            {
                pole.SetAbsoluteStrength(_poleStrength);
            }
        } 
    }

    public override float MagneticFieldAtOneMeter { get => PoleStrength / 15f; set => PoleStrength = value * 15; }

    public override void ToggleFieldVisualization()
    {
        if (!fieldVisualizer.Enabled)
        {
            fieldVisualizer.Reset();
            fieldVisualizer.VisualizeFieldLines(SouthPole);
        }
        else
        {
            fieldVisualizer.Reset();
        }
    }

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

    public override void UpdateFieldVisualization()
    {
        fieldVisualizer.UpdateFieldLines(SouthPole);
    }
}
