using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : StateMachineBehaviour
{
    public float velocityThreshold = -1.0f;
    ProcessControls processControls;
    private PlayerManager playerManager;

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
        if (processControls.GetHorizontalInput() == 0 && processControls.GetVerticalInput() == 0)
        {
            animator.Play("Idle");
        }

        if (processControls.GetIsJumpKeyPressed() && playerManager.CheckIfIsGrounded())
        {
            animator.Play("JumpEnter");
        }
      
        if (animator.gameObject.GetComponent<Rigidbody>().velocity.y < velocityThreshold && !playerManager.CheckIfIsGrounded())
        {
            animator.Play("JumpExit");
        }
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}