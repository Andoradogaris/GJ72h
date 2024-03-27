using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTrampolineState : StateMachineBehaviour
{
    private PlayerManager playerManager;
    private UIManager uiManager;
    bool crossFade;

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
        crossFade = false;

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= 0.99f && !crossFade)
        {
            playerManager.actualSeedCount++;
            uiManager.UpdateUI();
            Destroy(playerManager.selectedTrampoline);
            animator.CrossFade("Idle", 0.3f);
            crossFade = true;
            Debug.Log("Get Trampoline Success !!");
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        crossFade = false;
    }

}
