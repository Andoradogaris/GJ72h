using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverState : StateMachineBehaviour
{
    ProcessControls processControls;
    Rigidbody rb;
    public float velocityThreshold = -1.0f;
    bool crossFade;


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
        if (!processControls.GetIsJumpKeyHold() && !crossFade)
        {
            /*float velocityY = rb.velocity.y;

            if (velocityY < velocityThreshold)
            {
                animator.CrossFade("JumpExit", 0.3f);
                crossFade = true;
            }
            else
            {
                animator.CrossFade("JumpDropping", 0.3f);
                crossFade = true;
            }*/
            
            animator.CrossFade("JumpDropping", 0.3f);
            crossFade = true;
        }
        
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        crossFade = false;
    }
}