using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToAtCat : StateMachineBehaviour
{
    public string goAt = "JumpIdle";
    public float AtTime = 0.99f;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= AtTime)
        {
            animator.Play(goAt);
        }
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}