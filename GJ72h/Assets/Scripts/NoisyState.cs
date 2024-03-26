using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoisyState : StateMachineBehaviour
{
    PlayerManager playerManager;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerManager == null)
        {
            playerManager = animator.transform.root.GetComponent<PlayerManager>();
        }
        playerManager.SetNoisy(true);
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerManager.SetNoisy(false);
    }
}