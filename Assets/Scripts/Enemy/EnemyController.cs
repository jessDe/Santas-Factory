using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EnemyState State { get; private set; }

    private void Update()
    {
        switch (State) {
            case EnemyState.Patrolling:

                break;
            case EnemyState.Chasing:
                break;
            case EnemyState.Hunting:
                break;
            case EnemyState.Catching:
                break;
            default:
                break;
        }
    }
}
