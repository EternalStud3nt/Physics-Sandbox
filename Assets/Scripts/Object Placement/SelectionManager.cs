using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ObjectManipulation
{
    public static class SelectionManager
    {
        private static Camera _mainCamera;


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

        public static void OnObjectClicked(GameObject gameObject)
        {
            Debug.Log(gameObject.name + " has been clicked on");
            SelectedTransform = gameObject.transform;
            UIManager.Instance.DisplayGizmos(gameObject.transform);
        }

        public static Vector3 GetPointerPos()
        {
            Vector2 mousePos = InputManager.MouseScreenPos;
            Vector3 mouseScreenPos = new(
            mousePos.x,
            mousePos.y,
            MainCamera.WorldToScreenPoint(SelectedTransform.position).z
            );
            Vector3 newPos = MainCamera.ScreenToWorldPoint(mouseScreenPos);
            return newPos;
        }

    }
}
