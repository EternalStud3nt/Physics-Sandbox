using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_NeutralMenu : UI_SelectableMenu
{

    public void EnableObjectScaling()
    {
        ReferenceManager.Instance.TransformHandle.type = RuntimeHandle.HandleType.SCALE;
    }

}
