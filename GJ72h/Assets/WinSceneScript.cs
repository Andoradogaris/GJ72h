using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(winScene());
    }

    IEnumerator winScene()
    {
        yield return new WaitForSeconds(10);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    

}
