using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : StateMachineBehaviour
{
    CatProperties catProperties;
    Transform target;
    
    public float VisionAngle = 170.0f;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (catProperties == null)
        {
            catProperties = animator.transform.root.GetComponent<CatProperties>();
        }
        if (target == null)
        {
            target = catProperties.Player.transform;
        }
        
        
        
    }
    
    public bool CheckIfTargetIsVisible(Transform transform)
    {
        return MyMaths.IsOnVisibleZone(transform.position, target.position, VisionAngle, transform.rotation.eulerAngles.y);
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (CheckIfTargetIsVisible(animator.transform))
        {
            //TODO : use raycast to check if there is any obstacle between cat and player
            animator.Play("Chase");
        }
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}