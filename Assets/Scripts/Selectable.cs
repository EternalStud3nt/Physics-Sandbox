using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Selectable : MonoBehaviour, IPointerDownHandler
{
    public abstract MaterialType Type { get; }

    public enum MaterialType { Neutral, Ferromagnetic, Paramagnetic }


    public void OnPointerDown(PointerEventData eventData)
    {
        OnClick(gameObject);
    }

    public virtual void OnClick(GameObject gameObject)
    {
        SelectionManager.OnObjectClicked(gameObject);
    }
}
