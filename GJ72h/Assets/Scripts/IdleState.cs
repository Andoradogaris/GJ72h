using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    ProcessControls processControls;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls == null)
        {
            processControls = animator.transform.root.GetComponentInChildren<ProcessControls>();
        }
        Debug.Log("Idle");
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls.GetHorizontalInput() != 0 || processControls.GetVerticalInput() != 0)
        {
            animator.Play("Move");
        }

        if (processControls.GetIsJumpKeyPressed() == true)
        {
            animator.Play("JumpEnter");
        }
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}