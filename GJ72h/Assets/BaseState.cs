using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : StateMachineBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private GameObject test;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Base");
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RaycastHit hit;

        if(Input.GetKeyDown(KeyCode.P))
        {
            if(Physics.Raycast(animator.rootPosition, animator.transform.root.forward, out hit, range))
            {
                if (hit.transform.CompareTag("Trampoline"))
                {
                    animator.Play("GetTrampoline");
                    Destroy(hit.transform.gameObject);
                }
            }
            else
            {
                if (animator.GetComponent<PlayerManager>().seedCount > 0)
                {
                    animator.Play("DropTrampoline");
                }
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
