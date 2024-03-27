using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampJumpState : StateMachineBehaviour
{
    [SerializeField] private Vector3 impulseForce;
    bool crossFade;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        crossFade = false;

        if (!crossFade)
        {
            animator.CrossFade("TrampJumpRising", 0.3f);
            crossFade = true;
        }
        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        crossFade = false;
    }
}
