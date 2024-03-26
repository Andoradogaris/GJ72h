using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnterState : StateMachineBehaviour
{
    ProcessControls processControls;
    private Rigidbody rb;
    [SerializeField]Vector3 impulseForce;
    bool crossFade;

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
        rb.velocity = Vector3.zero;
        rb.AddForce(impulseForce + rb.velocity, ForceMode.Impulse);

    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime > 0.99f && !crossFade)
        {
            animator.CrossFade("JumpIdle", 0.3f);
            crossFade = true;
        }

    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        crossFade = false;
    }
}