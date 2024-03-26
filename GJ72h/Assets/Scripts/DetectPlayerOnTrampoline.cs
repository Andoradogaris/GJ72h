using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerOnTrampoline : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<Animator>().Play("TrampJump");
        }
    }
}
