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

    public void DeleteSelectedGameObject()
    {
        GameObject gameObj = SelectionManager.SelectedTransform.gameObject;
        SelectionManager.ClearSelection();
        Destroy(gameObj);
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

}
