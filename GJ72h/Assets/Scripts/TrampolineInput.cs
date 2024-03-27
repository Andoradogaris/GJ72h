using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineInput : StateMachineBehaviour
{
    ProcessControls processControls;
    private PlayerManager playerManager;
    private Transform trampoline;
    [SerializeField] private float range = 200;

    public float playerHeight = 2f;
    public float playerWidth = 0.5f;
        
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls == null)
        {
            processControls = animator.transform.root.GetComponentInChildren<ProcessControls>();
        }

        if (playerManager == null)
        {
            playerManager = animator.transform.root.GetComponent<PlayerManager>();
        }

        if(trampoline == null)
        {
            trampoline = playerManager.trampolineSpawnTransform.GetChild(0);
        }
    }

    bool foundTrampoline = false;
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Collider[] col = Physics.OverlapBox(playerManager.trampolineSpawnTransform.position, trampoline.lossyScale / 2);
        foundTrampoline = false;
        if (processControls.GetIsTrampolineKeyPressed())
        {
            foreach (Collider colTouch in col)
            {
                if (colTouch.transform.CompareTag("Trampoline"))
                {
                    Debug.Log("Toucher le trampoline");
                    animator.Play("GetTrampoline");
                    playerManager.selectedTrampoline = colTouch.gameObject;
                    foundTrampoline = true;
                }
            }
            
            if (!foundTrampoline)
            {
                //Collider[] groundCol = Physics.OverlapBox(playerManager.trampolineSpawnTransform.position, trampoline.lossyScale / 2);

                if (playerManager.actualSeedCount > 0 && col.Length <= 0)
                {
                    animator.Play("DropTrampoline");
                }
            }
        }
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}