using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CreationBar : MonoBehaviour
{
    public void CreateObject(GameObject prefab)
    {
        GameObject newObj = Instantiate(prefab, SelectionManager.MainCamera.transform.position + SelectionManager.MainCamera.transform.forward * 5f, Quaternion.identity);
        Selectable newSelectable = newObj.GetComponent<Selectable>();
        newSelectable.OnClick(newSelectable);
    }
}
