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
    private static ReferenceManager _referenceManager;

    public static Transform SelectedTransform { get; private set; }
    public static Selectable SelectedSelectable { get; private set; }
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
    public static ReferenceManager ReferenceManager
    {
        get
        {
            if (_referenceManager != null)
                return _referenceManager;
            else
            {
                _referenceManager = ReferenceManager.Instance;
                return _referenceManager;
            }
        }
    }


    public static void ClearSelection()
    {
        if (SelectedSelectable != null)
        {
            if (!SelectedSelectable.CanBePlaced)
            {
                return;
            }
            SelectedSelectable.OnDeselection();

        }

        SelectedTransform = null;
        SelectedSelectable = null;
        ReferenceManager.UI_Overlay.CloseSelectionInfoCard();
        TransformHandle.target = MainCamera.transform;
        ReferenceManager.UI_Overlay.EnableDeleteButton(false);
    }

    public static void OnObjectClicked(Selectable selectable)
    {
        if (SelectedSelectable != null)
        {
            ClearSelection();
            if (!SelectedSelectable.CanBePlaced) return;
        }
        SelectedTransform = selectable.transform;
        SelectedSelectable = selectable;
        SelectedSelectable.OnSelection();
        EnableMoveHandles();
        ReferenceManager.UI_Overlay.EnableDeleteButton(true);
    }

    public static void EnableMoveHandles()
    {
        TransformHandle.gameObject.SetActive(true);
        TransformHandle.target = SelectedTransform;
    }


}
