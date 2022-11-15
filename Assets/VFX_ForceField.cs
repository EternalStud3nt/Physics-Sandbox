using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_ForceField : MonoBehaviour
{
    public void SetRadius(float radius)
    {
        Transform oldParent = transform.parent;
        transform.parent = null;
        transform.localScale = new Vector3(1,1,1) * radius;
        transform.parent = oldParent;
        transform.position = transform.parent.position;
    }
}
