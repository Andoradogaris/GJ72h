using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverInput : StateMachineBehaviour
{
    ProcessControls processControls;
    bool crossFade;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls == null)
        {
            processControls = animator.transform.root.GetComponentInChildren<ProcessControls>();
        }
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (processControls.GetIsJumpKeyHold() && !crossFade)
        {
            animator.CrossFade("Hover", 0.3f);
            crossFade = true;
        }

    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        crossFade = false;
    }
}