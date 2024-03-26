using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnterState : StateMachineBehaviour
{
    ProcessControls processControls;
    private Rigidbody rb;
    [SerializeField]Vector3 impulseForce;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls == null)
        {
            processControls = animator.transform.root.GetComponentInChildren<ProcessControls>();
        }

        if (rb == null)
        {
            rb = animator.transform.root.GetComponent<Rigidbody>();
        }

        rb.AddForce(impulseForce + rb.velocity, ForceMode.Impulse);

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