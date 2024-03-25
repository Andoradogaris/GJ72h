using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public Transform target;
    public float VisionAngle = 170.0f;

    public bool CheckIfTargetIsVisible()
    {
        return MyMaths.IsOnVisibleZone(transform.position, target.position, VisionAngle, transform.rotation.eulerAngles.y);
    }
    
}
