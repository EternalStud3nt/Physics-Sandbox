using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ObjectManipulation
{
    public class Selectable : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            OnClick(gameObject);
        }

        public virtual void OnClick(GameObject gameObject)
        {
            SelectionManager.OnObjectClicked(gameObject);
        }
    }
}