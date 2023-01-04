using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CreationBar : MonoBehaviour
{
    public void CreateObject(GameObject prefab)
    {
        if (SelectionManager.SelectedSelectable != null)
        {
            if (!SelectionManager.SelectedSelectable.CanBePlaced) return;
        }
        GameObject newObj = Instantiate(prefab, SelectionManager.MainCamera.transform.position + SelectionManager.MainCamera.transform.forward * 2f, prefab.transform.rotation);
        Selectable newSelectable = newObj.GetComponent<Selectable>();
        newSelectable.OnClick(newSelectable);
    }
}
