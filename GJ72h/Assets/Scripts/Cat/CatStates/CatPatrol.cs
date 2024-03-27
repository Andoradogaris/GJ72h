using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPatrol : StateMachineBehaviour
{
    CatProperties catProperties;
    GameObject currentWaypoint;
    
    public float patrolSpeed = 2.0f;
    float oldSpeed;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (catProperties == null)
        {
            catProperties = animator.transform.root.GetComponent<CatProperties>();
        }
        catProperties.CatAgent.isStopped = false;
        currentWaypoint = catProperties.CurrentWaypoint;
        if (currentWaypoint == null)
        {
            catProperties.SetRandomWaypoint();
            currentWaypoint = catProperties.CurrentWaypoint;
        }
        catProperties.CatAgent.SetDestination(currentWaypoint.transform.position);
        Debug.Log("Patrolling");
        
        oldSpeed = catProperties.CatAgent.speed;
        catProperties.CatAgent.speed = patrolSpeed;
        
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (catProperties.CatAgent.pathPending)
        {
            return;
        }
        if (catProperties.CatAgent.remainingDistance <= 0.1f)
        {
            catProperties.CatAgent.speed = oldSpeed;
            catProperties.CatAgent.isStopped = true;
            animator.Play("Idle");
        }
        catProperties.CatAgent.SetDestination(currentWaypoint.transform.position);
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }
}