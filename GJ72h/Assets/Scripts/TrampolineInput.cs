using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineInput : StateMachineBehaviour
{
    ProcessControls processControls;
    private PlayerManager playerManager;
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
    }

    RaycastHit hit;
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls.GetIsTrampolineKeyPressed())
        {
            if (Physics.Raycast(animator.rootPosition, animator.transform.root.forward, out hit, range))
            {
                if (hit.transform.CompareTag("Trampoline"))
                {
                    animator.Play("GetTrampoline");
                    Destroy(hit.transform.gameObject);
                }
            }
            else
            {
                if (playerManager.seedCount > 0)
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