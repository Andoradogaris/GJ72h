using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewJumpDropping : StateMachineBehaviour
{
    PlayerManager playerManager;
    
    //public float jumpForce;
    public float jumpMultiplier;
    public AnimationCurve jumpForceCurve;

    float currentJumpTime;

    [SerializeField] bool isGettinUp;
    [SerializeField] bool isFloating;
    [SerializeField] bool isGettinDown;

    private float lastKeyTime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerManager == null)
        {
            playerManager = animator.transform.root.GetComponent<PlayerManager>();
        }
        
        Keyframe lastframe = jumpForceCurve[jumpForceCurve.length - 1 ];
        lastKeyTime = lastframe.time;
        
        currentJumpTime = 0;
    }
    float jumpForce;
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerManager.CheckIfIsGrounded())
        {
            Debug.Log("Dropping Grounded");
            animator.Play("Idle");
            return;
        }
        currentJumpTime += Time.deltaTime;
        if (!isFloating)
        {
            if (currentJumpTime >= lastKeyTime)
            {
                currentJumpTime = lastKeyTime;

            }
            Debug.Log("JumpForce: " + jumpForce);
            jumpForce = jumpForceCurve.Evaluate(currentJumpTime);
            animator.transform.root.Translate(0, jumpForce * jumpMultiplier * Time.deltaTime, 0);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
