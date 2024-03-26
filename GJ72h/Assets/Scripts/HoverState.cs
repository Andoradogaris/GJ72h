using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverState : StateMachineBehaviour
{
    ProcessControls processControls;
    Rigidbody rb;
    public float velocityThreshold = -1.0f;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls == null)
        {
            processControls = animator.transform.root.GetComponentInChildren<ProcessControls>();
        }

        if (rb == null)
        {
            rb = animator.transform.root.gameObject.GetComponent<Rigidbody>();
        }
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!processControls.GetIsJumpKeyHold())
        {
            float velocityY = rb.velocity.y;

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