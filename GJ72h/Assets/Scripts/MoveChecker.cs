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

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    bool CheckIfGameObjectHasLayer(GameObject obj, LayerMask layerMask)
    {
        // Vérifie si au moins un des calques spécifiés dans le masque de calques est présent dans le GameObject
        return (layerMask & (1 << obj.layer)) != 0;
    }
    RaycastHit[] allHits;

    void Update()
    {
        bool obstacleTop, obstacleMiddle, obstacleBottom;
        
        /*obstacleTop = Physics.Raycast(TopPoint.position, transform.forward, distance, cannotMoveLayer);
        obstacleMiddle = Physics.Raycast(MiddlePoint.position, transform.forward, distance, cannotMoveLayer);
        obstacleBottom = Physics.Raycast(BottomPoint.position, transform.forward, distance, cannotMoveLayer);
        CanMoveForward = !obstacleTop && !obstacleMiddle && !obstacleBottom;
        */
        // test sweepall test
        allHits = rb.SweepTestAll(transform.forward, distance);
        CanMoveForward = true;
        foreach (var hit in allHits)
        {
            if (CheckIfGameObjectHasLayer(hit.collider.gameObject, cannotMoveLayer))
            {
                Debug.Log("forward : " + hit.collider.gameObject.name);
                CanMoveForward = false;
                break;
            }
        }
        
        allHits = rb.SweepTestAll(-transform.forward, distance);
        CanMoveBackward = true;
        foreach (var hit in allHits)
        {
            if (CheckIfGameObjectHasLayer(hit.collider.gameObject, cannotMoveLayer))
            {
                CanMoveBackward = false;
                break;
            }
        }
        
        allHits = rb.SweepTestAll(-transform.right, distance);
        CanMoveLeft = true;
        foreach (var hit in allHits)
        {
            if (CheckIfGameObjectHasLayer(hit.collider.gameObject, cannotMoveLayer))
            {
                CanMoveLeft = false;
                break;
            }
        }
        

        allHits = rb.SweepTestAll(transform.right, distance);
        CanMoveRight = true;
        foreach (var hit in allHits)
        {
            if (CheckIfGameObjectHasLayer(hit.collider.gameObject, cannotMoveLayer))
            {
                CanMoveRight = false;
                break;
            }
        }
        
        
        /*Debug.DrawRay(TopPoint.position, transform.forward * distance, Color.red);
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
        Debug.DrawRay(BottomPoint.position, transform.right * distance, Color.red);*/
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
