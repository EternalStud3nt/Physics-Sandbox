using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable_Paramagnetic : Selectable
{
    [SerializeField] private Rigidbody _rigidbody;
    public override MaterialType Type => MaterialType.Paramagnetic;

    public override void OnDeselection()
    {
        _rigidbody.isKinematic = false;
    }

    public override void OnSelection()
    {
        _rigidbody.isKinematic = true;
    }
}
