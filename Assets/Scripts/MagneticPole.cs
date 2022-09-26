using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticPole : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private MagneticPole ignoredPole;

    [field: SerializeField] public float Strength { get; private set; } = 1;
    [field: SerializeField] public PoleType Type { get; private set; }

    public enum PoleType { North, South }

    public void SetPoleStrength(float strength)
    {
        Strength = strength;
    }

    public void ApplyForce(Vector3 force)
    {
        if (force.magnitude > 300) force = force.normalized * 300;
        rigidBody.AddForceAtPosition(force, transform.position, ForceMode.Force);
    }

    private void Start()
    {
        PhysicsManager.RegisterMagneticPole(this);    
    }

    private void FixedUpdate()
    {
        // Apply an attracting force to different type poles and a repelling one to the same type ones.
        foreach (MagneticPole pole in PhysicsManager.MagneticPoles)
        {
            if (pole == this) continue;
            bool attracted = pole.Type != Type;
            Vector3 deltaPos = pole.transform.position - transform.position;
            Vector3 forceDirection = (deltaPos).normalized;
            if (attracted) forceDirection *= -1;
            float forceMagnitude = Strength * pole.Strength / Mathf.Pow(deltaPos.magnitude, 1.5f);
            pole.ApplyForce(forceDirection * forceMagnitude);
        }

    }
}
