using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] Transform enemyPathHolder;
    [Range(0.1f, 1f)]
    [SerializeField] float pathVicinity;

    [Tooltip("Waittime between moving on to next point")]
    [Range(0f, 5f)]
    [SerializeField] float pointCooldown;

    [SerializeField] bool spawnOnPath;
    [SerializeField] bool onPatrol;

    Transform[] patrolPath;
    NavMeshAgent navAgent;
    int pathIndex;
    int pathSize;

    private void Start()
    {
        if (enemyPathHolder is null)
            Debug.LogError("Enemy has no path set.");

        navAgent = GetComponent<NavMeshAgent>();
        pathIndex = 0;
        pathSize = enemyPathHolder.childCount;

        patrolPath = new Transform[pathSize];
        var i = 0;
        foreach (Transform t in enemyPathHolder)
            patrolPath[i++] = t;

        if (onPatrol) navAgent.SetDestination(patrolPath[0].position);

        if (spawnOnPath)
            transform.position = new Vector3(patrolPath[0].position.x, GetComponent<CharacterController>().height, patrolPath[0].position.z);
    }
    private void FixedUpdate()
    {
        if (patrolPath is null) return;
        if (onPatrol is false) return;

        float dist = Vector3.Distance(transform.position, patrolPath[pathIndex].position);
        if (dist <= pathVicinity)
        {
            pathIndex = (pathIndex + 1) % pathSize;
            StartCoroutine(SetFollowPoint());
        }
    }

    private IEnumerator SetFollowPoint()
    {
        yield return new WaitForSeconds(pointCooldown);
        navAgent.SetDestination(patrolPath[pathIndex].position);
    }
}
