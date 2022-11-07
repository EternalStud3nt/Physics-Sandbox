using ObjectManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveGizmo : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Type type;

    private bool movingObject;
    private Vector3 startingPos;
    private Vector3 startingOffset;

    private enum Type { XZ, Y }

    public void OnPointerDown(PointerEventData eventData)
    {
        startingPos = SelectionManager.Position;
        startingOffset = -1 * (SelectionManager.GetPointerPos() - transform.position);
        movingObject = true;
    }

    private void Update()
    {
        if (movingObject)
        {
            if (type == Type.XZ)
            {
                TransformManipulator.MoveSelectedObjectXZ(startingPos, startingOffset);
            }
            else if (type == Type.Y)
            {
                TransformManipulator.MoveSelectedObjectY(startingPos, startingOffset);
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        startingPos = SelectionManager.Position;
        movingObject = false;
    }

}
