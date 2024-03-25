using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : StateMachineBehaviour
{
    ProcessControls processControls;
    [SerializeField] private float speed;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls == null)
        {
            processControls = animator.transform.root.GetComponent<ProcessControls>();
        }
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 dir = new Vector3(
                processControls.GetHorizontalInput() * speed * Time.deltaTime,
                0,
                processControls.GetVerticalInput() * speed * Time.deltaTime);

        animator.transform.root.Translate(dir);
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}