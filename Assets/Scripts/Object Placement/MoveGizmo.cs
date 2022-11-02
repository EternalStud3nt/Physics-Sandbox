using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveGizmo : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool movingObject;

    public void OnPointerDown(PointerEventData eventData)
    {
        movingObject = true;
    }

    private void Update()
    {
        if (movingObject)
        {
            TransformManipulator.MoveSelectedObjectXZ();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        movingObject = false;
    }

}
