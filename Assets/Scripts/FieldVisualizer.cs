using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GK;
using System;

public class FieldVisualizer : MonoBehaviour
{
    [SerializeField] FieldLine fieldLinePrefab;
    [SerializeField] MeshFilter meshFilter;

    private PermaMagnet magnet;
    private MagneticPole startingPole;


    public bool Enabled { get; private set; }

    public void VisualizeFieldLines()
    {
        List<Vector3> points = new List<Vector3>();
        Vector3 origin = startingPole.transform.position;

        for (float r = 0; r <= 0.3; r += 0.1f)
        {
            for (float thita = 0; thita <= 360; thita += 36)
            {
                const float depth = 0.4f;
                float x = Mathf.Cos(thita * Mathf.Deg2Rad);
                float y = Mathf.Sin(thita * Mathf.Deg2Rad);
                Vector3 direction = r * (magnet.transform.right * x + magnet.transform.forward * y) + magnet.transform.up * depth;
                Vector3 detectionPoint = origin + direction;
                points.Add(detectionPoint);
                FieldLine fieldLine = Instantiate(fieldLinePrefab, transform);
                fieldLine.transform.position = detectionPoint;
                fieldLine.Initialize(startingPole);
            }
        }
        Enabled = true;
    }

    public void UpdateFieldLines()
    {
        Reset();
        VisualizeFieldLines();
    }

    public void Reset()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        Enabled = false;
    }

    private void OnDeleteRequest()
    {
        Reset();
    }

    private void OnEnableRequest()
    {
        UpdateFieldLines();
    }

    private void Start()
    {
        magnet = GetComponentInParent<PermaMagnet>();
        Transform parent = transform.parent;
        MagneticPole[] poles = parent.GetComponentsInChildren<MagneticPole>();
        foreach (var pole in poles)
        {
            if (pole.Type == MagneticPole.PoleType.South)
            {
                startingPole = pole;
            }
        }
        SettingsBar.OnDeleteFieldLinesRequest += OnDeleteRequest;
        SettingsBar.OnEnableAllFieldLinesRequest += OnEnableRequest;
    }

    private void OnDestroy()
    {
        SettingsBar.OnEnableAllFieldLinesRequest -= OnEnableRequest;
        SettingsBar.OnDeleteFieldLinesRequest -= OnDeleteRequest;
    }
}
