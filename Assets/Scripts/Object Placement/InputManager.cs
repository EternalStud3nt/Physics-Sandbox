using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectManipulation
{
    public class InputManager : MonoBehaviour
    {
        public static Vector2 MouseScreenPos
        {
            get
            {
                return Input.mousePosition;
            }
        }

    }
}