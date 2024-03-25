using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int seedCount;
    public Transform trampolineSpawnTransform;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float radius;

    public bool CheckIfIsGrounded()
    {
        Collider[] hitColliders = Physics.OverlapSphere(groundChecker.position, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                return true;
            }
        }
        return false;
    }
}
