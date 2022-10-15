using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticPole : MonoBehaviour
{
    [SerializeField] protected Rigidbody rigidBody;
    [SerializeField] protected List<MagneticPole> ignoredPoles;

    [field: SerializeField] public float Strength { get; private set; } = 1;
    [field: SerializeField] public PoleType Type { get; private set; }

    public enum PoleType { North, South }

    public virtual void ApplyForce(Vector3 force)
    {
        rigidBody.AddForceAtPosition(force, transform.position, ForceMode.Force);
    }

    /// <summary>
    /// Returns a vector with magnitude equal to the magnetic field at that point and direction from the pole to that point
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    public Vector3 CalculateFieldAtPoint(Vector3 point)
    {
        Vector3 deltaPos = point - transform.position;
        return deltaPos.normalized * (Strength  / Mathf.Pow(deltaPos.magnitude, 2));
    }

    public void MultiplyPoleStrength(float multiplier)
    {
        Strength *= multiplier;
    }

    public void SetStrength(float strength)
    {
        Strength = strength;
    }

    public void IgnorePole(MagneticPole pole)
    {
        ignoredPoles.Add(pole);
    }

    public bool IsIgnoringPole(MagneticPole pole)
    {
        return ignoredPoles.Contains(pole);
    }

    protected virtual void FixedUpdate()
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
            ApplyForce(-1 * forceMagnitude * forceDirection);
        }
    }

    private void Start()
    {
        PhysicsManager.RegisterMagneticPole(this);
        //todo: This should update if new poles are added or deleted
        foreach (MagneticPole pole in PhysicsManager.MagneticPoles)
        {
            if (!pole.IsIgnoringPole(this))
            {
                IgnorePole(pole);
            }
        }
    }

    private void OnDestroy()
    {
        PhysicsManager.UnRegisterMagneticPole(this);
    }

    private void OnDrawGizmos()
    {
        //if (Type == PoleType.South)
        //    Gizmos.color = Color.blue;
        //else 
        //    Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, fieldRadius);
    }
}
