using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerOnTrampoline : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player");
            other.GetComponentInChildren<Animator>().Play("TrampJump");
            m_Animator.Play("Trampoline_Boing");
        }
    }
}
