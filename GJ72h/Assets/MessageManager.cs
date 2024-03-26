
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageManager : MonoBehaviour
{
    public Text messageText;
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