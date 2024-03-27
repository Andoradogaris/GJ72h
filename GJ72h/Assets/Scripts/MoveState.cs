using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : StateMachineBehaviour
{
    ProcessControls processControls;
    [SerializeField] private float speed;
    MoveChecker moveChecker;
    
    Rigidbody rb;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls == null)
        {
            processControls = animator.transform.root.GetComponent<ProcessControls>();
        }
        if (moveChecker == null)
        {
            moveChecker = animator.transform.root.GetComponent<MoveChecker>();
        }
        if (rb == null)
        {
            rb = animator.transform.root.gameObject.GetComponent<Rigidbody>();
        }
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 dir = new Vector3(
            processControls.GetHorizontalInput(),
            0,
            processControls.GetVerticalInput());
        dir = dir.normalized * speed * Time.deltaTime;

        
        
        animator.transform.root.Translate(moveChecker.GetMoveDirection(dir));
        
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}