using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationTarget : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int wayPointIndex;
    Vector3 target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWayPointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = waypoints[wayPointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWayPointIndex()
    {
        wayPointIndex++;
        if (wayPointIndex == waypoints.Length)
        {
            wayPointIndex = 0;
        }
    }
}
