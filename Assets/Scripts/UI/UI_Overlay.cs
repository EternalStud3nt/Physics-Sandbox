using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Overlay : MonoBehaviour
{
    [SerializeField] private FreeFlyCamera _freeFlyCamera;
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private UI_SelectionInfoCard _selectionInfoCard;
    [SerializeField] private Button _infoButton;
    [SerializeField] private Button _deleteButton;

    private ReferenceManager _referenceManager;

    public void DeleteAllFieldLines()
    {

    }

    public void DeleteAllObjects()
    {

    }

    public void EnableDeleteButton(bool enable)
    {
        if (enable) _deleteButton.gameObject.SetActive(true);
        else _deleteButton.gameObject.SetActive(false);
    }

    public void DeleteSelectedGameObject()
    {
        GameObject gameObj = SelectionManager.SelectedTransform.gameObject;
        SelectionManager.ClearSelection();
        Destroy(gameObj);
    }

    public void ToggleTransformMode()
    {
        if (_referenceManager.TransformHandle.type == RuntimeHandle.HandleType.POSITION)
        {
            _referenceManager.TransformHandle.type = RuntimeHandle.HandleType.ROTATION;
        }
        else if (_referenceManager.TransformHandle.type == RuntimeHandle.HandleType.ROTATION)
        {
            _referenceManager.TransformHandle.type = RuntimeHandle.HandleType.POSITION;
        }
    }

    public void EnterCameraMode()
    {
        _freeFlyCamera.EnterFlyMode();
        SelectionManager.ClearSelection();
        _selectionInfoCard.Close();
    }

    public void OpenSelectionInfoCard()
    {
        _selectionInfoCard.Open(SelectionManager.SelectedSelectable);
    }

    public void CloseSelectionInfoCard()
    {
        _selectionInfoCard.Close();
    }

    private void Start()
    {
        _referenceManager = ReferenceManager.Instance;
    }
}
