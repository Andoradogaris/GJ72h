using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnterState : StateMachineBehaviour
{
    ProcessControls processControls;
    [SerializeField]Vector3 impulseForce;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls == null)
        {
            processControls = animator.transform.root.GetComponentInChildren<ProcessControls>();
        }
        Debug.Log("JumpEnter");

        animator.transform.root.GetComponentInChildren<Rigidbody>().AddForce(impulseForce + animator.transform.GetComponent<Rigidbody>().velocity, ForceMode.Impulse);

    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime > 0.99f)
        {
            animator.Play("JumpIdle");
        }

    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}