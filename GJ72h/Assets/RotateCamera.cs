using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : StateMachineBehaviour
{
    [SerializeField] private float sensitivity;
     private GameObject followTarget;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(followTarget == null)
        {
            followTarget = GameObject.FindWithTag("FollowTarget");
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;

        animator.transform.root.Rotate(Vector3.up * mouseX);
        followTarget.transform.Rotate(Vector3.left * mouseY);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
