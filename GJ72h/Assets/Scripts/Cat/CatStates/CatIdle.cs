using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatIdle : StateMachineBehaviour
{
    CatProperties catProperties;
    
    public float cuurentIdleTime = 5.0f;
    public float maxIdleTime = 5.0f;
    
    bool idleComplete = false;
    
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (catProperties == null)
        {
            catProperties = animator.transform.root.GetComponent<CatProperties>();
        }
        idleComplete = false;
        cuurentIdleTime = maxIdleTime;
        Debug.Log("Idling");
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cuurentIdleTime -= Time.deltaTime;
        if (cuurentIdleTime <= 0 && !idleComplete)
        {
            catProperties.SetRandomWaypoint();
            animator.Play("Patrol");
            idleComplete = true;
        }
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}