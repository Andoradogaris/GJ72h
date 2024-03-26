using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineInput : StateMachineBehaviour
{
    ProcessControls processControls;
    private PlayerManager playerManager;
    private Transform trampoline;
    [SerializeField] private float range = 200;

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

    RaycastHit hit;
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.DrawRay(animator.rootPosition, animator.transform.root.forward * range, Color.red);
        if (processControls.GetIsTrampolineKeyPressed())
        {
            
            if (Physics.Raycast(animator.rootPosition, animator.transform.root.forward, out hit, range))
            {
                Debug.Log("Toucher le raycast" + hit.transform.name);
                if (hit.transform.CompareTag("Trampoline"))
                {
                    Debug.Log("Toucher le trampoline");
                    animator.Play("GetTrampoline");
                    Destroy(hit.transform.gameObject);
                }
            }
            else
            {
                Collider[] col = Physics.OverlapBox(playerManager.trampolineSpawnTransform.position, trampoline.lossyScale / 2);
                Collider[] groundCol = Physics.OverlapBox(playerManager.trampolineSpawnTransform.position, trampoline.lossyScale / 2);


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