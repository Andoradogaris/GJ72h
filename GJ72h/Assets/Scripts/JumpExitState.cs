using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpExitState : StateMachineBehaviour
{
    ProcessControls processControls;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls == null)
        {
            processControls = animator.transform.root.GetComponentInChildren<ProcessControls>();
        }
        Debug.Log("JumpExit");
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls.isGrounded)
        {
            animator.Play("Idle");
        }
        
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}