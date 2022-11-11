using ObjectManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformManipulator : MonoBehaviour
{
    public static void MoveSelectedObjectXZ(Vector3 startingPos, Vector3 offset)
    {
        offset.y = 0;
        Vector3 newPos = ObjectManipulation.SelectionManager.GetPointerPos();
        SelectionManager.SelectedTransform.position = new Vector3(newPos.x, startingPos.y, newPos.z) + offset;
    }

    public static void MoveSelectedObjectY(Vector3 startingPos, Vector3 offset)
    {
        offset.x = 0; offset.z = 0;
        Vector3 newPos = ObjectManipulation.SelectionManager.GetPointerPos();
        SelectionManager.SelectedTransform.position = new Vector3(startingPos.x, newPos.y, startingPos.z) + offset;
    }
}
