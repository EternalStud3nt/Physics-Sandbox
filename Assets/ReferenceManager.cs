using RuntimeHandle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour
{
    [SerializeField] private RuntimeTransformHandle transformHandle;

    public static ReferenceManager Instance { get; private set; }

    public RuntimeTransformHandle TransformHandle { get { return transformHandle; } }

    private void Awake()
    {
        Instance = this;
    }
}
