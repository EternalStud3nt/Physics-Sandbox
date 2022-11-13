using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable_Neutral : Selectable
{
    public override MaterialType Type => MaterialType.Neutral;

    public override void OnDeselection()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnSelection()
    {
        //throw new System.NotImplementedException();
    }
}
