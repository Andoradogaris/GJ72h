using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTrampolineState : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Get");
        animator.GetComponent<PlayerManager>().seedCount++;
        animator.Play("Base");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
