using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpIdleState : StateMachineBehaviour
{
    public float velocityThreshold = -1.0f;
    bool crossFade;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        float velocityY = animator.transform.root.GetComponent<Rigidbody>().velocity.y;

        if (velocityY < velocityThreshold && !crossFade)
        {
            animator.CrossFade("JumpExit", 0.3f);
            crossFade = true;
        }
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        crossFade = false;
    }
}