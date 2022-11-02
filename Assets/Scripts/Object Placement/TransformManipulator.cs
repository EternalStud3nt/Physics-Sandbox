using ObjectManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformManipulator : MonoBehaviour
{
    public static void MoveSelectedObjectXZ()
    {
        Vector3 startingPos = SelectionManager.StartingPosition;
        Vector3 mouseScreenPos = new(
            Input.mousePosition.x,
            Input.mousePosition.y,
            SelectionManager.MainCamera.WorldToScreenPoint(SelectionManager.SelectedTransform.position).z
            );
        Vector3 newPos = SelectionManager.MainCamera.ScreenToWorldPoint(mouseScreenPos);
        SelectionManager.SelectedTransform.position = new(newPos.x, startingPos.y, newPos.z);
    }

    private void Update()
    {
        //Debug.Log(SelectionManager.MouseWorldPos + " / " + SelectionManager.MousePos);
    }
}
