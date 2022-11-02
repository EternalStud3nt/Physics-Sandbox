using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ObjectManipulation
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Transform gizmoGroup;
        [SerializeField] private Image xyMovePlane;

        public static UIManager Instance;

        private Transform followedTransform;

        public void DisplayGizmos(Transform followTransform)
        {
            followedTransform = followTransform;
            gizmoGroup.gameObject.SetActive(true);
            gizmoGroup.transform.position = followTransform.position;
        }

        public void Update()
        {
            if (followedTransform != null)
                gizmoGroup.position = followedTransform.position;
        }

        private void Awake()
        {
            Instance = this;
        }
    }
}