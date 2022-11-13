using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamagneticMaterial : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float poleOrbitRadius;
    [SerializeField] private MagneticPole southPole;
    [SerializeField] private MagneticPole northPole;


    private void FixedUpdate()
    {
        Vector3 fieldDirection = FieldDetector.GetTotalField(transform.position, new List<MagneticPole> { southPole, northPole }).normalized;
        southPole.transform.position = transform.position + fieldDirection * poleOrbitRadius;
        northPole.transform.position =  transform.position + -1 * poleOrbitRadius * fieldDirection;
    }
}
