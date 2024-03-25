using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChase : StateMachineBehaviour
{
    CatProperties catProperties;
    
    public float chaseSpeed = 5.0f;
    public float stopChaseDistance = 100.0f;
    public float attackDistance = 1.0f;
    
    public float oldSpeed;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (catProperties == null)
        {
            catProperties = animator.transform.root.GetComponent<CatProperties>();
        }
        oldSpeed = catProperties.agent.speed;
        catProperties.agent.speed = chaseSpeed;
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
        
        catProperties.agent.SetDestination(catProperties.Player.transform.position);
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        catProperties.agent.speed = oldSpeed;
    }
}