using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : Enemy
{
    public Transform[] waypoints;
    private int waypointIndex;
    private int distance;

    private void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    private void Update()
    {
        distance = (int)Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if (distance < 1f)
        {
            IncreaseIndex();
        }
        Patrol();
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * FlyweightPointer.Enemy.speed * Time.deltaTime);
    }

    void IncreaseIndex() 
    {
        waypointIndex++;
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }

        transform.LookAt(waypoints[waypointIndex].position);
    }
}
