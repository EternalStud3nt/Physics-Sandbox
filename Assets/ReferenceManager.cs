using RuntimeHandle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    [SerializeField] private RuntimeTransformHandle transformHandle;
    [SerializeField] private UI_Overlay _uiOverlay;

    public static ReferenceManager Instance { get; private set; }

    public UI_Overlay UI_Overlay => _uiOverlay;
    public RuntimeTransformHandle TransformHandle { get { return transformHandle; } }

    private void Awake()
    {
        Instance = this;
    }
}
