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
        OnClick(gameObject.GetComponent<Selectable>());
    }

    public virtual void OnClick(Selectable gameObject)
    {
        SelectionManager.OnObjectClicked(gameObject);
    }

    public abstract void OnSelection();

    public abstract void OnDeselection();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SelectionManager.ClearSelection();
        }
    }

}
