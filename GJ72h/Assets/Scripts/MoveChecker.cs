using System;
using UnityEngine;

public class MoveChecker : MonoBehaviour
{
    public LayerMask cannotMoveLayer;
    public Transform TopPoint;
    public Transform MiddlePoint;
    public Transform BottomPoint;

    public bool CanMoveForward;
    public bool CanMoveBackward;
    public bool CanMoveLeft;
    public bool CanMoveRight;

    public float distance = 1.0f;
    void Update()
    {
        bool obstacleTop, obstacleMiddle, obstacleBottom;
        
        obstacleTop = Physics.Raycast(TopPoint.position, transform.forward, distance, cannotMoveLayer);
        obstacleMiddle = Physics.Raycast(MiddlePoint.position, transform.forward, distance, cannotMoveLayer);
        obstacleBottom = Physics.Raycast(BottomPoint.position, transform.forward, distance, cannotMoveLayer);
        CanMoveForward = !obstacleTop && !obstacleMiddle && !obstacleBottom;
        
        obstacleTop = Physics.Raycast(TopPoint.position, -transform.forward, distance, cannotMoveLayer);
        obstacleMiddle = Physics.Raycast(MiddlePoint.position, -transform.forward, distance, cannotMoveLayer);
        obstacleBottom = Physics.Raycast(BottomPoint.position, -transform.forward, distance, cannotMoveLayer);
        CanMoveBackward = !obstacleTop && !obstacleMiddle && !obstacleBottom;
        
        obstacleTop = Physics.Raycast(TopPoint.position, -transform.right, distance, cannotMoveLayer);
        obstacleMiddle = Physics.Raycast(MiddlePoint.position, -transform.right, distance, cannotMoveLayer);
        obstacleBottom = Physics.Raycast(BottomPoint.position, -transform.right, distance, cannotMoveLayer);
        CanMoveLeft = !obstacleTop && !obstacleMiddle && !obstacleBottom;
        
        obstacleTop = Physics.Raycast(TopPoint.position, transform.right, distance, cannotMoveLayer);
        obstacleMiddle = Physics.Raycast(MiddlePoint.position, transform.right, distance, cannotMoveLayer);
        obstacleBottom = Physics.Raycast(BottomPoint.position, transform.right, distance, cannotMoveLayer);
        CanMoveRight = !obstacleTop && !obstacleMiddle && !obstacleBottom;
        
        
        Debug.DrawRay(TopPoint.position, transform.forward * distance, Color.red);
        Debug.DrawRay(MiddlePoint.position, transform.forward * distance, Color.red);
        Debug.DrawRay(BottomPoint.position, transform.forward * distance, Color.red);
        
        Debug.DrawRay(TopPoint.position, -transform.forward * distance, Color.red);
        Debug.DrawRay(MiddlePoint.position, -transform.forward * distance, Color.red);
        Debug.DrawRay(BottomPoint.position, -transform.forward * distance, Color.red);
        
        Debug.DrawRay(TopPoint.position, -transform.right * distance, Color.red);
        Debug.DrawRay(MiddlePoint.position, -transform.right * distance, Color.red);
        Debug.DrawRay(BottomPoint.position, -transform.right * distance, Color.red);
        
        Debug.DrawRay(TopPoint.position, transform.right * distance, Color.red);
        Debug.DrawRay(MiddlePoint.position, transform.right * distance, Color.red);
        Debug.DrawRay(BottomPoint.position, transform.right * distance, Color.red);
    }

    public Vector3 GetMoveDirection(Vector3 baseDirection)
    {
        if (baseDirection.z > 0 && !CanMoveForward)
        {
            baseDirection.z = 0;
        }
        if (baseDirection.z < 0 && !CanMoveBackward)
        {
            baseDirection.z = 0;
        }
        if (baseDirection.x > 0 && !CanMoveRight)
        {
            baseDirection.x = 0;
        }
        if (baseDirection.x < 0 && !CanMoveLeft)
        {
            baseDirection.x = 0;
        }
        return baseDirection;
    }
    
}
