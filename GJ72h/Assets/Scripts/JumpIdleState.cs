using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpIdleState : StateMachineBehaviour
{
    public float velocityThreshold = -1.0f;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("JumpIdle");

    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        float velocityY = animator.gameObject.GetComponent<Rigidbody>().velocity.y;

        if (velocityY < velocityThreshold)
        {
            animator.Play("JumpExit");
        }
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}