using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampJumpState : StateMachineBehaviour
{
    [SerializeField] private Vector3 impulseForce;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<Rigidbody>().AddForce(impulseForce, ForceMode.Impulse);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
