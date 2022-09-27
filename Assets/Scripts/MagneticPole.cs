using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticPole : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private List<MagneticPole> ignoredPoles;

    private float fieldRadius;

    [field: SerializeField] public float Strength { get; private set; } = 1;
    [field: SerializeField] public PoleType Type { get; private set; }

    public enum PoleType { North, South }

    public void MultiplyPoleStrength(float multiplier)
    {
        Strength *= multiplier;
    }

    public void ApplyForce(Vector3 force)
    {
        rigidBody.AddForceAtPosition(force, transform.position, ForceMode.Force);
    }

    private void Start()
    {
        PhysicsManager.RegisterMagneticPole(this);
        fieldRadius = Strength / Mathf.Sqrt(40);
    }

    private void FixedUpdate()
    {
        // Apply an attracting force to different type poles and a repelling one to the same type ones.
        foreach (MagneticPole pole in PhysicsManager.MagneticPoles)
        {
            if (pole == this || ignoredPoles.Contains(pole)) continue;
            bool attracted = pole.Type != Type;
            Vector3 deltaPos = pole.transform.position - transform.position;
            Vector3 forceDirection = (deltaPos).normalized;
            if (attracted) forceDirection *= -1;
            float forceMagnitude = Strength * pole.Strength / Mathf.Pow(deltaPos.magnitude, 2); // r = sqrt(8/strenght^2)
            print(forceMagnitude);
            pole.ApplyForce(forceDirection * forceMagnitude);
        }

    }

    private void OnDestroy()
    {
        PhysicsManager.UnRegisterMagneticPole(this);
    }

    private void OnDrawGizmos()
    {
        if (Type == PoleType.South)
            Gizmos.color = Color.blue;
        else 
            Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldRadius);
    }
}
