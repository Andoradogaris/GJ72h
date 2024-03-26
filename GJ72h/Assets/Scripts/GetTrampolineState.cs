using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTrampolineState : StateMachineBehaviour
{
    private PlayerManager playerManager;
    private UIManager uiManager;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerManager == null)
        {
            playerManager = animator.transform.root.transform.GetComponent<PlayerManager>();
        }

        if (uiManager == null)
        {
            uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        }

        playerManager.actualSeedCount++;
        uiManager.UpdateUI();
        animator.Play("Idle");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
