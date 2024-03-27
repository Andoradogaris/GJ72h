using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int actualSeedCount;
    public int maxSeedCount;
    public Transform trampolineSpawnTransform;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private Transform headChecker;
    [SerializeField] private float radius;
    [SerializeField] bool isNoisy = false;
    [SerializeField] bool debugGrounded = false;
    
    [SerializeField] private Transform trampolineChecker;
    public GameObject selectedTrampoline;

    public Transform GetTrampolineChecker()
    {
        return trampolineChecker;
    }
    
    public void SetNoisy(bool heard)
    {
        isNoisy = heard;
    }
    
    public bool IsNoisy()
    {
        return isNoisy;
    }
    private void Awake()
    {
        actualSeedCount = maxSeedCount;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

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
    
    public bool CheckIfIsHeadHit()
    {
        Collider[] hitColliders = Physics.OverlapSphere(headChecker.position, radius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                return true;
            }
        }
        return false;
    }

    private void Update()
    {
        debugGrounded = CheckIfIsGrounded();
        if(actualSeedCount > maxSeedCount)
        {
            maxSeedCount = actualSeedCount;
            GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().UpdateUI();
        }
    }
}
