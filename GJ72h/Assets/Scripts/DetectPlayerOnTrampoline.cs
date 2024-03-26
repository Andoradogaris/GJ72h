using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerOnTrampoline : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        if (other.CompareTag("Player"))
        {
            Debug.Log("player");
            other.GetComponentInChildren<Animator>().Play("TrampJump");
        }
    }
}
