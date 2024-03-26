using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverInput : StateMachineBehaviour
{
    ProcessControls processControls;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls == null)
        {
            processControls = animator.transform.root.GetComponentInChildren<ProcessControls>();
        }
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (processControls.GetIsJumpKeyHold())
        {
            animator.Play("Hover");
        }

    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}