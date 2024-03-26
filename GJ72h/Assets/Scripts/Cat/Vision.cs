using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public Transform target;
    public float VisionAngle = 170.0f;

    public LayerMask obstacleLayer;
    public VisionChecks visionChecks;
    
    
    public float maxHearingDistance = 10.0f;
    
    public bool IsTargetDetected()
    {
        return TargetIsVisible() || IsTargetNoiseDetected();
    }
    
    public bool TargetIsVisible()
    {
        bool isInVisibleZone = MyMaths.IsOnVisibleZone(transform.position, target.position, VisionAngle, transform.rotation.eulerAngles.y);
        bool obstacleBetween = Physics.Linecast(transform.position, target.position, obstacleLayer);

        if (visionChecks == VisionChecks.Zone)
        {
            if (isInVisibleZone)
            {
                return true;
            }
        }
        else if (visionChecks == VisionChecks.ZoneAndObstacle)
        {
            if (isInVisibleZone && !obstacleBetween)
            {
                return true;
            }
        }
        return false;
    }
    
    public bool IsTargetNoiseDetected()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= maxHearingDistance)
        {
            if (target.TryGetComponent(out PlayerProperties playerProperties))
            {
                return playerProperties.IsNoisy();
            }
        }
        return false;
    }
    
}



public enum VisionChecks
{
    Zone,
    ZoneAndObstacle,
}