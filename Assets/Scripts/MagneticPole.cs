using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticPole : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private MagneticPole attachedPole;

    [field: SerializeField] public float Strength { get; private set; } = 1;
    [field: SerializeField] public PoleType Type { get; private set; }

    public enum PoleType { North, South }

    private void Start()
    {
        PhysicsManager.RegisterMagneticPole(this);    
    }

    public void ApplyForce(Vector3 force)
    {
        rigidBody.AddForceAtPosition(force, transform.position);
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
            Debug.Log("Direction: " + forceDirection + ", Magnitude: " + forceMagnitude);
            pole.ApplyForce(forceDirection * forceMagnitude);
        }

    }
}
