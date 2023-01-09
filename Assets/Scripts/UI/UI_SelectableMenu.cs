using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class UI_SelectableMenu : MonoBehaviour
{
    [SerializeField] protected TMP_Text objectName;
    [SerializeField] protected TMP_Text objectDescription;

    public virtual void Initialize(Selectable selectable)
    {
        SetObjectName(selectable.ObjectName);
        SetObjectDescription(selectable.ObjectDescrition);
    }

    public void SetObjectName(string name)
    {
        objectName.text = name;
    }

    public void SetObjectDescription(string desc)
    {
        objectDescription.text = desc;
    }
}
