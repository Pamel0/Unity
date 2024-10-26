using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePlatform : MonoBehaviour
{
    public List<Transform> waypoints; 
    public float speed = 2f; 
    private int currentWaypointIndex = 0;
    private bool isMoving = false; 
    private bool isReturning = false; 

    void Update()
    {
        if (isMoving && waypoints.Count > 0)
        {
            MoveTowardsWaypoint();
        }
    }

    private void MoveTowardsWaypoint()
    {
        Transform target = waypoints[currentWaypointIndex];
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            if (isReturning)
            {
                currentWaypointIndex--; 
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 1; 
                    isReturning = false; 
                }
            }
            else
            {
                currentWaypointIndex++; 
                if (currentWaypointIndex >= waypoints.Count)
                {
                    currentWaypointIndex = waypoints.Count - 2; 
                    isReturning = true; 
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz wszed³ na platformê.");
            isMoving = true; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz zszed³ z platformy.");
            isMoving = false; 
        }
    }
}
