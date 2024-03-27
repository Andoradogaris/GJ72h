
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class MessageManager : MonoBehaviour
{
    public static MessageManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public TMP_Text messageText;
    public float displayDuration = 3f; 

    public void ShowMessage(string message)
    {
        StartCoroutine(DisplayMessage(message));
    }

    IEnumerator DisplayMessage(string message)
    {
        messageText.text = message;
        messageText.enabled = true;

        yield return new WaitForSeconds(displayDuration);

        messageText.text = "";
        messageText.enabled = false;
    }
}