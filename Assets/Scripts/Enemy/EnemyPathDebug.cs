using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathDebug : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Vector3[] path = new Vector3[transform.childCount];
        var i = 0;
        foreach (Transform t in transform)
            path[i++] = t.position;

        transform.Children().Each((point, index) => Gizmos.DrawSphere(point.position, 0.25f));
        Gizmos.DrawLineStrip(path, true);
    }
}
