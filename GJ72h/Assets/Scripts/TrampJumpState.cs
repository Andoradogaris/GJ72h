using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampJumpState : StateMachineBehaviour
{
    [SerializeField] private Vector3 impulseForce;
    private Rigidbody rb;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (rb == null)
        {
            rb = animator.transform.root.GetComponent<Rigidbody>();
        }

        rb.velocity = Vector3.zero;
        rb.AddForce(impulseForce, ForceMode.Impulse);
        animator.Play("JumpExit");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
