using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GK;
using System;

public class FieldVisualizer : MonoBehaviour
{
    [SerializeField] FieldLine fieldLinePrefab;
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] MagneticPole startingPole;

    public bool Enabled { get; private set; }

    public void VisualizeFieldLines(MagneticPole startingPole)
    {
        List<Vector3> points = new List<Vector3>();
        Vector3 origin = startingPole.transform.position;

        //for (float r = 0; r <= 0.3; r += 0.1f)
        {
            float r = 0.3f;
            for (float thita = 0; thita <= 360; thita += 36)
            {
                const float y = 0.4f;
                float x = Mathf.Cos(thita * Mathf.Deg2Rad);
                float z = Mathf.Sin(thita * Mathf.Deg2Rad);
                Vector3 direction = r * (transform.right * x + transform.forward * z) + transform.up* y;
                Vector3 detectionPoint = origin + direction;
                points.Add(detectionPoint);
                FieldLine fieldLine = Instantiate(fieldLinePrefab, transform);
                fieldLine.transform.position = detectionPoint;
                fieldLine.Initialize(startingPole);
            }
        }
        Enabled = true;
    }

    public void UpdateFieldLines(MagneticPole startingPole)
    {
        Reset();
        VisualizeFieldLines(startingPole);
    }

    private void Start()
    {
        VisualizeFieldLines(startingPole);
    }

    internal void Reset()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        Enabled = false;
    }
}
