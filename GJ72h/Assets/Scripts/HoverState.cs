using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverState : StateMachineBehaviour
{
    public float velocityThreshold = -1.0f;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            float velocityY = animator.gameObject.GetComponent<Rigidbody>().velocity.y;

            if (velocityY < velocityThreshold)
            {
                animator.Play("JumpExit");
            }
            else
            {
                animator.Play("JumpIdle");
            }
        }
        
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}