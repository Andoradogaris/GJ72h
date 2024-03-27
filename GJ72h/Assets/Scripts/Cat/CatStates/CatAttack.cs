using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAttack : StateMachineBehaviour
{
    public CatProperties catProperties;
    public float attackRange;
    public bool playerHit = false;
    public bool animEnd = false;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerHit = false;
        animEnd = false;
        if (catProperties == null)
        {
            catProperties = animator.transform.root.GetComponent<CatProperties>();
        }
        animator.transform.root.LookAt(catProperties.Player.transform);
        animator.transform.root.transform.rotation = Quaternion.Euler(0, animator.transform.root.transform.rotation.eulerAngles.y, 0);
        Debug.Log("Attacking");
    }
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime >= 0.5f && !playerHit)
        {
            Collider[] hitColliders = Physics.OverlapSphere(catProperties.PlayerDetectionPoint.position, attackRange);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Player"))
                {
                    playerHit = true;
                    Debug.Log("Lose !!");
                    UnityEngine.SceneManagement.SceneManager.LoadScene(3);
                }
            }
        }
        if (stateInfo.normalizedTime >= 0.99f && !animEnd)
        {
            animator.Play("Idle");
            animEnd = true;
        }
    }
    
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}