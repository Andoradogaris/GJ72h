using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : StateMachineBehaviour
{
    public float velocityThreshold = -1.0f;
    ProcessControls processControls;
    private PlayerManager playerManager;
    bool crossFade;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls == null)
        {
            processControls = animator.transform.root.GetComponentInChildren<ProcessControls>();
        }

        if (playerManager == null)
        {
            playerManager = animator.transform.root.GetComponent<PlayerManager>();
        }
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls.GetHorizontalInput() == 0 && processControls.GetVerticalInput() == 0 && !crossFade)
        {
            animator.CrossFade("Idle", 0.3f);
            crossFade = true;
        }

        if (processControls.GetIsJumpKeyPressed() && playerManager.CheckIfIsGrounded() && !crossFade)
        {
            animator.CrossFade("JumpEnter", 0.3f);
            crossFade = true;
        }
      
        if (animator.transform.root.GetComponent<Rigidbody>().velocity.y < velocityThreshold && !playerManager.CheckIfIsGrounded() && !crossFade)
        {
            animator.CrossFade("JumpDropping", 0.3f);
            crossFade = true;
        }
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        crossFade = false;
    }
}