using ObjectManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MonoBehaviour
{
    [ExecuteAlways]
    private void LateUpdate()
    {
        Vector3 cameraDir = SelectionManager.MainCamera.transform.forward;
        cameraDir.y = 0;
        transform.rotation = Quaternion.LookRotation(cameraDir);
    }
}
