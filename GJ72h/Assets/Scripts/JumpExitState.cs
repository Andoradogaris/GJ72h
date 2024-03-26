using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpExitState : StateMachineBehaviour
{
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
        if (playerManager.CheckIfIsGrounded() && !crossFade)
        {
            animator.CrossFade("Idle", 0.3f);
            crossFade = true;
        }
        
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        crossFade = false;
    }
}