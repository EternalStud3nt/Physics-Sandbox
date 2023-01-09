using ObjectManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PermaMagnet : Selectable
{
    [SerializeField] private int fieldLineLength = 200;
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float _poleStrength;
    [SerializeField] private FieldVisualizer fieldVisualizer;

    private MagneticPole[] _poles;


    public float Mass
    {
        get
        {
            return rigidBody.mass;
        }
        private set
        {
            rigidBody.mass = value;
        }
    }

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

    public float MagneticFieldAtOneMeter { get => PoleStrength / 15f; set => PoleStrength = value * 15; }

    public override MaterialType Type => MaterialType.Ferromagnetic;


    public void ChangeMass(float value)
    {
        Mass += value;
    }

    public void ToggleFieldVisualization()
    {
        if (!fieldVisualizer.Enabled)
        {
            fieldVisualizer.Reset();
            fieldVisualizer.VisualizeFieldLines();
        }
        else
        {
            fieldVisualizer.Reset();
        }
    }
    
    public void UpdateFieldVisualization()
    {
        fieldVisualizer.UpdateFieldLines();
    }

    public override void OnDeselection()
    {
        base.OnDeselection();
        rigidBody.isKinematic = false;
    }

    public override void OnSelection()
    {
        base.OnSelection();
        rigidBody.isKinematic = true;
    }

    protected override void Awake()
    {
        base.Awake();
        PoleStrength = _poleStrength;
    }

}
