using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAttack : StateMachineBehaviour
{
    
    public float tempTimer = 2.0f;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tempTimer = 2.0f;
        
        Debug.Log("Attacking");
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tempTimer -= Time.deltaTime;
        if (tempTimer <= 0)
        {
            animator.Play("Idle");
        }
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}