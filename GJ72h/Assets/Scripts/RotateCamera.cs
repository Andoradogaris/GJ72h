using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : StateMachineBehaviour
{
     private GameObject followTarget;
    
     ProcessControls processControls;
     
     public float verticalLimitMin = 80;
     public float verticalLimitMax = 300;
     
     
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (processControls == null)
        {
            processControls = animator.transform.root.GetComponent<ProcessControls>();
        }
        if(followTarget == null)
        {
            followTarget = GameObject.FindWithTag("FollowTarget");
        }
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.transform.root.Rotate(Vector3.up * processControls.GetCameraHorizontalInput());
        //followTarget.transform.Rotate(Vector3.left * processControls.GetCameraVerticalInput());
        
        float verticalInput = processControls.GetCameraVerticalInput();
        float horizontalInput = processControls.GetCameraHorizontalInput();
        animator.transform.root.Rotate(Vector3.up * horizontalInput);

        
        Debug.Log("Euler x : "+followTarget.transform.eulerAngles.x);
        if (verticalInput < 0)
        {
            Debug.Log("verticalInput < 0");
        }
        else if (verticalInput > 0)
        {
            Debug.Log("verticalInput > 0");
        }
        else
        {
            Debug.Log("verticalInput == 0");
        }
        
        
        followTarget.transform.Rotate(Vector3.left * verticalInput);

        if (followTarget.transform.eulerAngles.x > verticalLimitMin &&
            followTarget.transform.eulerAngles.x < verticalLimitMax)
        {
            /*if (followTarget.transform.eulerAngles.x > verticalLimitMin)
            {
                followTarget.transform.eulerAngles = new Vector3(
                    verticalLimitMin,
                    followTarget.transform.eulerAngles.y,
                    0);
            }
            else if (followTarget.transform.eulerAngles.x < verticalLimitMax)
            {
                followTarget.transform.eulerAngles = new Vector3(
                    verticalLimitMax,
                    followTarget.transform.eulerAngles.y,
                    0);
            
            }*/
        }

        
    }
}
