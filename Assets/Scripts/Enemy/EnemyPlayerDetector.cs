using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetector : MonoBehaviour
{
    [Range(35f, 105f)]
    [SerializeField] float viewAngle;

    [Range(0.1f, 10f)]
    [SerializeField] float viewRange;

    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (IsPlayerDetected())
            GetComponent<MeshRenderer>().material.color = Color.red;
        else
            GetComponent<MeshRenderer>().material.color = Color.gray;
    }

    private bool IsPlayerDetected()
    {
        Vector3 toTarget = player.position - transform.position;
        if (Vector3.Angle(transform.forward, toTarget) > viewAngle) return false;
        if (!Physics.Raycast(transform.position, toTarget, out RaycastHit hit, viewRange)) return false;
        if (hit.transform.root.Equals(player)) return true;

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * viewRange);
    }
}
