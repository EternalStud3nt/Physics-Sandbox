using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selectable_Ferromagnetic : Selectable
{
    public override MaterialType Type => MaterialType.Ferromagnetic;
    public abstract float MagneticFieldAtOneMeter { get; set; }

    public abstract void ToggleFieldVisualization();
    public abstract void UpdateFieldVisualization();
}
