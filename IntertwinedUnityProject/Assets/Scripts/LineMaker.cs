using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineMaker : MonoBehaviour
{
    public GameObject Line;
    public List<Vector3> positions;
    private LineRenderer line;
    public int PointsOnLine;
    public float min, max;
    public float XDistance;
    public bool Sin;

    void Awake()
    {
        line = Line.GetComponent<LineRenderer>();
        line.SetVertexCount(PointsOnLine);
        positions = new List<Vector3>();
        for (int i = 0; i < PointsOnLine; i++)
        {
            if (Sin)
            {
                positions.Add(new Vector3(i * XDistance, Random.Range(0.0f, 1.0f) * Mathf.Sin(i + Random.Range(-1.0f, 1.0f)), 0));
            }
            else
            {
                positions.Add(new Vector3(i * XDistance, Random.Range(0.0f, 1.0f) * Mathf.Sin(i + 180 + Random.Range(-1.0f, 1.0f)), 0));
            }
            line.SetPosition(i, positions[i]);
        }
    }

    void Update()
    {
        for (int i = 0; i < positions.Count; i++)
        {
            line.SetPosition(i, positions[i]);
        }
    }
}
