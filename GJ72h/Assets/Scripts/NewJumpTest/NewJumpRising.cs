using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewJumpRising : StateMachineBehaviour
{
    PlayerManager playerManager;
    
    //public float jumpForce;
    public float jumpMultiplier;
    public float maxJumpTime;
    public bool UseAnimLenghtForMaxTime;
    public AnimationCurve jumpForceCurve;

    public float currentJumpTime;
    public float lastKeyTime;

    public float maxJumpFloatTime;
    float currentJumpFloatTime;

    [SerializeField] bool isGettinUp;
    [SerializeField] bool isFloating;
    [SerializeField] bool isGettinDown;

    bool curveEnd;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerManager == null)
        {
            playerManager = animator.transform.root.GetComponent<PlayerManager>();
        }
        
        Keyframe lastframe = jumpForceCurve[jumpForceCurve.length - 1 ];
        lastKeyTime = lastframe.time;
        
        if (UseAnimLenghtForMaxTime)
        {
            maxJumpTime = stateInfo.length;
        }
        currentJumpTime = 0;
        curveEnd = false;
    }
    float jumpForce;
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (playerManager.CheckIfIsHeadHit())
        {
            Debug.Log("Head hit");
            animator.Play("JumpDropping");
            return;
        }

        if (currentJumpTime <= maxJumpTime && !isFloating)
        {
            currentJumpTime += Time.deltaTime;
        }
        
        if (!isFloating)
        {
            float timeToUse = 0;
            if (UseAnimLenghtForMaxTime)
            {
                timeToUse = stateInfo.normalizedTime;
                if (stateInfo.normalizedTime >= 1)
                {
                    Debug.Log("Rise Curve end normalizedTime");
                    curveEnd = true;
                }
            }
            else
            {
                timeToUse = currentJumpTime / maxJumpTime;
            }

            if (timeToUse >= lastKeyTime)
            {
                timeToUse = lastKeyTime;
                if (!UseAnimLenghtForMaxTime)
                {
                    Debug.Log("Rise Curve end lastKeyTime");
                    curveEnd = true;
                }
            }
            
            jumpForce = jumpForceCurve.Evaluate(timeToUse);
            animator.transform.root.Translate(0, jumpForce * jumpMultiplier * Time.deltaTime, 0);
        }
        
        if (curveEnd)
        {
            animator.Play("JumpDropping");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
