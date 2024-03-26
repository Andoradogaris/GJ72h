using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTrampolineState : StateMachineBehaviour
{
    [SerializeField] private GameObject trampoline;
    private PlayerManager playerManager;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(playerManager == null)
        {
            playerManager = animator.transform.root.transform.GetComponent<PlayerManager>();
        }

        Transform trampolineSpawn = playerManager.trampolineSpawnTransform;
        Instantiate(trampoline, trampolineSpawn.position, trampolineSpawn.rotation);
        animator.Play("Idle");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerManager.seedCount--;
    }
}
