using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFallState : StateMachineBehaviour
{    
    private PlayerManager playerManager;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerManager == null)
        {
            playerManager = animator.transform.root.GetComponent<PlayerManager>();
        }
        

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Retour à l'état Idle
        if (playerManager.CheckIfIsGrounded())
        {
            // Debug.Log("Retour à l'état Idle");
            animator.Play("Idle");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
