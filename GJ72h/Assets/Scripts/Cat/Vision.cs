using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    public Transform target;
    public float VisionAngle = 170.0f;

    public LayerMask obstacleLayer;
    public VisionChecks visionChecks;

    [SerializeField] bool isTargetVisible;
    [SerializeField] bool isTargetNoiseDetected;
    
    
    
    public float maxHearingDistance = 10.0f;
    
    public bool IsTargetDetected()
    {
        return GetTargetIsVisible() || GetTargetNoiseDetected();
    }

    public bool GetTargetNoiseDetected()
    {
        return isTargetNoiseDetected;
    }

    public bool GetTargetIsVisible()
    {
        return isTargetVisible;
    }

    public void SetTargetIsVisible()
    {
        bool isInVisibleZone = MyMaths.IsOnVisibleZone(transform.position, target.position, VisionAngle, transform.rotation.eulerAngles.y);
        bool obstacleBetween = Physics.Linecast(transform.position, target.position, obstacleLayer);

        if (visionChecks == VisionChecks.Zone)
        {
            if (isInVisibleZone)
            {
                isTargetVisible = true;
                return;
            }
        }
        else if (visionChecks == VisionChecks.ZoneAndObstacle)
        {
            if (isInVisibleZone && !obstacleBetween)
            {
                isTargetVisible = true;
                return;
            }
        }
        isTargetVisible = false;
    }
    
    public void SetIsTargetNoiseDetected()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= maxHearingDistance)
        {
            if (target.TryGetComponent(out PlayerManager playerManager))
            {
                isTargetNoiseDetected = playerManager.IsNoisy();
                return;
            }
        }
        isTargetNoiseDetected = false;
        return;
    }

    void Update()
    {
        SetTargetIsVisible();
        SetIsTargetNoiseDetected();
    }

}



public enum VisionChecks
{
    Zone,
    ZoneAndObstacle,
}