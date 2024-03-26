using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatPlayerDetection : StateMachineBehaviour
{
    CatProperties catProperties;
    Vision vision;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (catProperties == null)
        {
            catProperties = animator.transform.root.GetComponent<CatProperties>();
        }
        if (vision == null)
        {
            vision = catProperties.CatVision;
        }
    }
    
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (vision.CheckIfTargetIsVisible())
        {
            animator.Play("Chase");
        }
        
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}