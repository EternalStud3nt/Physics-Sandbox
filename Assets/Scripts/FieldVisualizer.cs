using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GK;

public class FieldVisualizer : MonoBehaviour
{
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] List<MagneticPole> poles;

    public List<Vector3> CalculateFieldPoints(List<MagneticPole> poles, Vector3 origin)
    {

        List<Vector3> fieldPoints = new List<Vector3>();
        for (int phi = 0; phi <= 360; phi += 5)
        {
            for (int thita = 0; thita <= 180; thita += 5)
            {
                float z = Mathf.Cos(thita);
                float x = Mathf.Sin(thita) * Mathf.Cos(phi);
                float y = Mathf.Sin(thita) * Mathf.Sin(phi);
                Vector3 direction = new Vector3(x, y, z);
                Vector3 detectionPoint = origin + direction;
                fieldPoints.Add(detectionPoint);
            }
        }

        for (int index = 0; index < fieldPoints.Count; index++)
        {
            Vector3 fieldPoint = fieldPoints[index];
            float chosenScalar = 1;
            Vector3 closestField  = Vector3.one * 1000;
            for (float scalar = 0; scalar <= 5; scalar += 0.05f)
            {
                Vector3 checkPoint = origin + (fieldPoint - origin) * scalar;
                Vector3 totalField = new Vector3();
                foreach (MagneticPole pole in poles)
                {
                    totalField += pole.CalculateFieldAtPoint(checkPoint);
                }
                if (Mathf.Abs(totalField.magnitude - 1) <= Mathf.Abs(closestField.magnitude - 1))
                {
                    closestField = totalField;
                    chosenScalar = scalar;
                }
            }
            fieldPoints[index] = (fieldPoint - origin) * chosenScalar;
            Debug.Log(chosenScalar);
        }
        return fieldPoints;
    }

    private void Start()
    {
        List<Vector3> verts = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector3> normals = new List<Vector3>();

        List<Vector3> points = CalculateFieldPoints(poles, transform.position);
        var calc = new ConvexHullCalculator();
        calc.GenerateHull(points, true, ref verts, ref triangles, ref normals);

        Mesh mesh = new Mesh();
        mesh.SetVertices(verts);
        mesh.SetTriangles(triangles, 0);
        mesh.SetNormals(normals);
        meshFilter.mesh = mesh;
    }
}
