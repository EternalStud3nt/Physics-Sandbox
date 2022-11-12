using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selectable_Ferromagnetic : Selectable
{
    public override MaterialType Type => MaterialType.Ferromagnetic;
    public abstract float MagneticField { get; set; }
}
