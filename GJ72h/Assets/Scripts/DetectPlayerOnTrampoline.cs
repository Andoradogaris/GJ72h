using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerOnTrampoline : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;

    float maxTime = 0.5f;
    bool canUse = true;
    //public Transform playerChecker;
    
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player");
            other.GetComponentInChildren<Animator>().Play("TrampJumpEnter");
            m_Animator.Play("Trampoline_Boing");
        }
    }
    */

    private void Start()
    {
        canUse = true;
    }

    private Collider[] touchedColliders;
    private void Update()
    {
        // using overlap box to detect player with lossy scale
        if (!canUse)
        {
            return;
        }
        touchedColliders = Physics.OverlapBox(transform.position, transform.lossyScale / 2, transform.rotation);
        foreach (var touchedCollider in touchedColliders)
        {
            if (touchedCollider.CompareTag("Player"))
            {
                Debug.Log("player detected on trampoline");
                touchedCollider.GetComponentInChildren<Animator>().Play("TrampJumpEnter");
                m_Animator.Play("Trampoline_Boing");
                canUse = false;
                StartCoroutine(resetTrampoline());
            }
        }
    }
    
    IEnumerator resetTrampoline()
    {
        yield return new WaitForSeconds(maxTime);
        canUse = true;
    }
}
