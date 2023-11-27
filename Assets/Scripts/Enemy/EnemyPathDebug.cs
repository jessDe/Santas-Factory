using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathDebug : MonoBehaviour
{
    private void OnDrawGizmos() =>
        transform.DrawChildrenPath(true);
}
