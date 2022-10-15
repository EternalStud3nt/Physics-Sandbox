using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamagneticMaterial : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private FieldDetector fieldDetector;
    [SerializeField] private float strength;

    private void ApplyForces()
    {
        foreach (MagneticPole pole in PhysicsManager.MagneticPoles)
        {
            Vector3 poleForce = pole.CalculateFieldAtPoint(transform.position) * strength;
            pole.ApplyForce(poleForce);
            rigidBody.AddForce(-1 * poleForce);
        }
    }

    private void FixedUpdate()
    {
        ApplyForces();
    }
}
