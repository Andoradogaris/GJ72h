using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
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
        if (!playerManager.CheckIfIsGrounded())
        {
            animator.Play("JumpDropping");
        }

        if (processControls.GetHorizontalInput() != 0 || processControls.GetVerticalInput() != 0)
        {
            animator.Play("Walk");
        }

        if (processControls.GetIsJumpKeyPressed() && playerManager.CheckIfIsGrounded())
        {
            animator.Play("JumpEnter");
        }


    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}