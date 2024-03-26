using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoisyState : StateMachineBehaviour
{
    PlayerProperties playerProperties;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerProperties == null)
        {
            playerProperties = animator.transform.root.GetComponent<PlayerProperties>();
        }
        playerProperties.SetNoisy(true);
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerProperties.SetNoisy(false);
    }
}