using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTrampolineState : StateMachineBehaviour
{
    [SerializeField] private GameObject trampoline;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Drop");
        Transform trampolineSpawn = animator.GetComponent<PlayerManager>().trampolineSpawnTransform;
        Instantiate(trampoline, trampolineSpawn.position, trampolineSpawn.rotation);
        animator.Play("Base");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PlayerManager>().seedCount--;
    }
}
