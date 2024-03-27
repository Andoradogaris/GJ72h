using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGland : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().actualSeedCount++;
            GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().UpdateUI();
            Destroy(gameObject);
        }
    }
}
