using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewJumpState : StateMachineBehaviour
{
    //public float jumpForce;
    public float jumpMultiplier;
    public float maxJumpTime;
    public bool UseAnimLenghtForMaxTime;
    public AnimationCurve jumpForceCurve;

    float currentJumpTime;

    public float maxJumpFloatTime;
    float currentJumpFloatTime;

    [SerializeField] bool isGettinUp;
    [SerializeField] bool isFloating;
    [SerializeField] bool isGettinDown;

    private float lastKeyTime;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Keyframe lastframe = jumpForceCurve[jumpForceCurve.length - 1 ];
        lastKeyTime = lastframe.time;
        
        if (UseAnimLenghtForMaxTime)
        {
            maxJumpTime = stateInfo.length;
        }
        currentJumpTime = 0;
        isGettinUp = true;
        isGettinDown = false;
        isFloating = false;
    }
    float jumpForce;
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        if (currentJumpTime <= maxJumpTime && !isFloating)
        {
            currentJumpTime += Time.deltaTime;
        }

        if (currentJumpTime >= maxJumpTime /2)
        {
            currentJumpTime += 0;
            if (isGettinUp)
            {
                isGettinUp = false;
                isGettinDown = false;
                isFloating = true;
            }
        }

        if (!isFloating)
        {
            float timeToUse = 0;
            if (UseAnimLenghtForMaxTime)
            {
                timeToUse = stateInfo.normalizedTime;
            }
            else
            {
                timeToUse = currentJumpTime / maxJumpTime;
            }

            if (timeToUse >= lastKeyTime)
            {
                timeToUse = lastKeyTime;
            }
            jumpForce = jumpForceCurve.Evaluate(timeToUse);
            
            animator.transform.root.Translate(0, jumpForce * jumpMultiplier * Time.deltaTime, 0);
        }

        if (isFloating)
        {
            currentJumpFloatTime += Time.deltaTime;
            if (currentJumpFloatTime >= maxJumpFloatTime)
            {
                isFloating = false;
                currentJumpFloatTime = 0;
                isGettinUp = false;
                isGettinDown = true;
            }

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
