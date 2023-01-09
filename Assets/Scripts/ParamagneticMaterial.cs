using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamagneticMaterial : Selectable
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float poleOrbitRadius;
    [SerializeField] private MagneticPole southPole;
    [SerializeField] private MagneticPole northPole;


    private float initialMass;
    private Vector3 initialScale;
    private List<MagneticPole> poles;

    public override MaterialType Type => MaterialType.Paramagnetic;


    public float MultiplyMass(float multiplier)
    {
        float finalDivInitialMass = (multiplier * rigidBody.mass) / initialMass;
        if (finalDivInitialMass <= 0.25f || finalDivInitialMass >= 10)
        {
            return (float)Math.Round(rigidBody.mass, 2);
        }
        else
        {
            rigidBody.mass = multiplier * rigidBody.mass;
            transform.localScale = finalDivInitialMass * initialScale;
            MultiplyForce(finalDivInitialMass);
            return (float)Math.Round(rigidBody.mass, 2);
        }
    }

    private void MultiplyForce(float value)
    {
        foreach (var pole in poles)
        {
            pole.SetAbsoluteStrength(pole.Strength * Mathf.Pow(value, 0.5f));
        }
    }


    private void Start()
    {
        poles = new List<MagneticPole>(GetComponentsInChildren<MagneticPole>());
        initialMass = rigidBody.mass;
        initialScale = transform.localScale;
    }

    private void FixedUpdate()
    {
        Vector3 fieldDirection = FieldDetector.GetTotalField(transform.position, new List<MagneticPole> { southPole, northPole }).normalized;
        southPole.transform.position = transform.position + fieldDirection * poleOrbitRadius;
        northPole.transform.position = transform.position + -1 * poleOrbitRadius * fieldDirection;
    }
}
