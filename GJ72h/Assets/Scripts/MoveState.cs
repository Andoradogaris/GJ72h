using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : StateMachineBehaviour
{
    public float velocityThreshold = -1.0f;
    ProcessControls processControls;
    [SerializeField] private float speed;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls == null)
        {
            processControls = animator.transform.root.GetComponentInChildren<ProcessControls>();
        }
        Debug.Log("Move");

    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls.GetHorizontalInput() == 0 && processControls.GetVerticalInput() == 0)
        {
            animator.Play("Idle");
        }
        else
        {
            Vector3 dir = new Vector3(
                processControls.GetHorizontalInput() * speed * Time.deltaTime, 
                0, 
                processControls.GetVerticalInput() * speed * Time.deltaTime);

            animator.transform.root.Translate(dir);
        }

        if (processControls.GetIsJumpKeyPressed() == true)
        {
            animator.Play("JumpEnter");
        }
      
        if (animator.gameObject.GetComponent<Rigidbody>().velocity.y < velocityThreshold)
        {
            animator.Play("JumpExit");
        }
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}