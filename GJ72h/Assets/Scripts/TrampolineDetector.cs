using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineDetector : StateMachineBehaviour
{
    PlayerManager playerManager;
    bool crossFade;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerManager == null)
        {
            playerManager = animator.transform.root.GetComponent<PlayerManager>();
        }
        crossFade = false;
    }
    
    Collider[] collidersTouched;
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (crossFade)
        {
            return;
        }
        collidersTouched = Physics.OverlapSphere(playerManager.GetTrampolineChecker().position, 0.5f);
        if (collidersTouched.Length > 0)
        {
            foreach (Collider col in collidersTouched)
            {
                if (col.CompareTag("Trampoline"))
                {
                    animator.Play("TrampJumpEnter");
                    crossFade = true;
                }
            }
        }
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}