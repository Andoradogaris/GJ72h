using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTrampolineState : StateMachineBehaviour
{
    [SerializeField] private GameObject trampoline;
    private PlayerManager playerManager;
    private UIManager uiManager;
    bool crossFade;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(playerManager == null)
        {
            playerManager = animator.transform.root.transform.GetComponent<PlayerManager>();
        }

        if(uiManager == null)
        {
            uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= 0.99f && !crossFade)
        {
            Transform trampolineSpawn = playerManager.trampolineSpawnTransform;
            Instantiate(trampoline, trampolineSpawn.position, trampolineSpawn.rotation);
            animator.CrossFade("Idle", 0.3f);
            crossFade = true;
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerManager.actualSeedCount--;
        uiManager.UpdateUI();
        crossFade = false;
    }
}
