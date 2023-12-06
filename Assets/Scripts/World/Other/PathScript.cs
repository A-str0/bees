using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    public List<Transform> points = new List<Transform>();

    private void Start() {
        for (int i = 0; i < transform.childCount; ++i) {
            points.Add(transform.GetChild(i));
        }
    }

    public int GetNearestPointIndex(Vector3 pos) {
        float dist = float.MaxValue; int index = 0;
        for (int i = 0; i < points.Count; ++i) {
            if (Vector3.Distance(pos, points[i].position) < dist) {
                dist = Vector3.Distance(pos, points[i].position);
                index = i;
            }
        }
        return index;
    }
}
