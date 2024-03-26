using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class CatProperties : MonoBehaviour
{
    public GameObject[] Waypoints;
    public NavMeshAgent CatAgent;
    public Vision CatVision;
    
    public GameObject Player;

    void Start()
    {
        
        if (Player == null)
        {
            Player = GameObject.FindWithTag("Player");
        }
        
        if (CatVision.target == null)
        {
            CatVision.target = Player.transform;
        }
    }

    public GameObject GetRandomWaypoint()
    {
        return Waypoints[Random.Range(0, Waypoints.Length)];
    }
    
    
    public GameObject CurrentWaypoint { get; private set; }
    
    public void SetCurrentWaypoint(GameObject waypoint)
    {
        CurrentWaypoint = waypoint;
    }
    
    public void SetRandomWaypoint()
    {
        int maxTries = 10;
        int currentTries = 0;
        var randomWaypoint = GetRandomWaypoint();
        while (randomWaypoint == CurrentWaypoint)
        {
            randomWaypoint = GetRandomWaypoint();
            currentTries++;
            if (currentTries >= maxTries)
            {
                break;
            }
        }
        
        SetCurrentWaypoint(randomWaypoint);
 
    }
    
}
