using ObjectManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BarMagnet : MonoBehaviour, ISelectable
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float poleStrength;

    public void OnPointerDown(PointerEventData eventData)
    {
        this.GetComponent<ISelectable>().OnClick(gameObject);
    }

    private void Awake()
    {
        MagneticPole[] poles = transform.GetComponentsInChildren<MagneticPole>();
        foreach (MagneticPole pole in poles)
        {
            pole.SetAbsoluteStrength(poleStrength);
        }
    }
}
