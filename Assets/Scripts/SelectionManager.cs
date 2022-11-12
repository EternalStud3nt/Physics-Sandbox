using RuntimeHandle;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public static class SelectionManager
{
    private static Camera _mainCamera;
    private static RuntimeTransformHandle _transformHandle;

    public static Transform SelectedTransform { get; private set; }
    public static Vector3 Position { get { return SelectedTransform.position; } }
    public static Camera MainCamera
    {
        get
        {
            if (_mainCamera != null)
            {
                return _mainCamera;
            }
            else
            {
                _mainCamera = Camera.main;
                return _mainCamera;
            }
        }
    }
    public static RuntimeTransformHandle TransformHandle
    {
        get
        {
            if (_transformHandle != null)
            {
                return _transformHandle;
            }
            else
            {
                _transformHandle = ReferenceManager.Instance.TransformHandle;
                return _transformHandle;
            }
        }
    }


    public static void ClearSelection()
    {
        SelectedTransform = null;
        TransformHandle.gameObject.SetActive(false);
    }

    public static void OnObjectClicked(GameObject gameObject)
    {
        Debug.Log(gameObject.name + " has been clicked on");
        SelectedTransform = gameObject.transform;
        EnableMoveHandles();
        ShowInfoCard();
    }

    public static void EnableMoveHandles()
    {
        if (!TransformHandle.gameObject.activeInHierarchy) TransformHandle.gameObject.SetActive(true);
        TransformHandle.target = SelectedTransform;
    }

    private static void ShowInfoCard()
    {
        ReferenceManager.Instance.UI_Overlay.OpenSelectionInfoCard(SelectedTransform.GetComponent<Selectable>());
    }

    
}
