using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectIfInVoid : MonoBehaviour
{
    [SerializeField] private List<GameObject> raypoints;

    void Start()
    {
        //int layerMask = 1 << 2;

        //layerMask = ~layerMask;

        //foreach (GameObject raypoint in raypoints)
        //{
        //    if (!Physics.Raycast(raypoint.transform.position, Vector3.down, 1f, layerMask))
        //    {

        //        Debug.Log("Pas bon");
        //        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //        Debug.Log(player);
        //        PlayerManager playerManager = player.GetComponent<PlayerManager>();
        //        Debug.Log(playerManager);

        //        playerManager.actualSeedCount++;
        //        Destroy(gameObject);
        //        break;
        //    }
        //    else
        //    {
        //        gameObject.layer = LayerMask.GetMask("Ground");
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
