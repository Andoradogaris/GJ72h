using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewJumpStartState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (stateInfo.normalizedTime  > 0.1f)
        {
            animator.Play("JumpRising");
        }
    }

}
