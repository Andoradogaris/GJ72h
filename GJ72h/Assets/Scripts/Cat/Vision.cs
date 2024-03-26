using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public Transform target;
    public float VisionAngle = 170.0f;

    public LayerMask obstacleLayer;
    
    public VisionChecks visionChecks;
    
    public bool CheckIfTargetIsVisible()
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
}

public enum VisionChecks
{
    Zone,
    ZoneAndObstacle,
}