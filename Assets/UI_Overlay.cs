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

    public void EnterCameraMode()
    {
        _freeFlyCamera.EnterFlyMode();
        SelectionManager.ClearSelection();
        _selectionInfoCard.Close();
    }

    public void OpenSelectionInfoCard(Selectable selectable)
    {
        _selectionInfoCard.Open(selectable);
    }
}
