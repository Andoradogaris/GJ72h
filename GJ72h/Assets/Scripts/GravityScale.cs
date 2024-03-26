using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScale : StateMachineBehaviour
{
    public float gravity = 1f;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Physics.gravity = new Vector3(0, gravity, 0);
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}