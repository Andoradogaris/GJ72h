using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPlayerChase : StateMachineBehaviour
{
    CatProperties catProperties;
    
    public float chaseSpeed = 5.0f;
    public float stopChaseDistance = 100.0f;
    public float attackDistance = 1.0f;
    
    private float oldSpeed;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (catProperties == null)
        {
            catProperties = animator.transform.root.GetComponent<CatProperties>();
        }
        catProperties.CatAgent.isStopped = false;
        oldSpeed = catProperties.CatAgent.speed;
        catProperties.CatAgent.speed = chaseSpeed;
        
        Debug.Log("Chasing");
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(catProperties.Player.transform.position, catProperties.transform.position) <= attackDistance)
        {
            animator.Play("Attack");
            return;
        }
        if (Vector3.Distance(catProperties.Player.transform.position, catProperties.transform.position) >= stopChaseDistance)
        {
            animator.Play("Idle");
            return;
        }
        
        catProperties.CatAgent.SetDestination(catProperties.Player.transform.position);
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        catProperties.CatAgent.isStopped = true;
        catProperties.CatAgent.speed = oldSpeed;
    }
}