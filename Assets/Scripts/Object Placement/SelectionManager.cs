using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ObjectManipulation
{
    public static class SelectionManager
    {
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
        public static Vector2 MousePos
        {
            get
            {
                return Input.mousePosition;
            }
        }
        public static Vector3 MouseWorldPos
        {
            get
            {
                Vector3 mousePos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
                //Debug.Log(mousePos + " / " + MainCamera.transform.position);
                return MainCamera.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        private static Camera _mainCamera;


        public static void OnObjectClicked(GameObject gameObject)
        {
            Debug.Log(gameObject.name + " has been clicked on");
            SelectedTransform = gameObject.transform;
            UIManager.Instance.DisplayGizmos(gameObject.transform);
        }

        public static Vector3 GetPointerPos()
        {       
            Vector3 mouseScreenPos = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            MainCamera.WorldToScreenPoint(SelectedTransform.position).z
            );
            Vector3 newPos = MainCamera.ScreenToWorldPoint(mouseScreenPos);
            return newPos;
        }

    }

    public interface ISelectable : IPointerDownHandler
    {
        public virtual void OnClick(GameObject gameObject)
        {
            SelectionManager.OnObjectClicked(gameObject);
        }
    }
}
