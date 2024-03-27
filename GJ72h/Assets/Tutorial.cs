using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MessageManager.instance.ShowMessage("I need to reach the window in order to escape.");
    }

    IEnumerator continueTutorial()
    {
        yield return new WaitForSeconds(MessageManager.instance.displayDuration);
        MessageManager.instance.ShowMessage("I need to be careful, if the cat sees me or if I make noise near it, it will attack me.");
        yield return new WaitForSeconds(MessageManager.instance.displayDuration);
        MessageManager.instance.ShowMessage("Fortunately, I have my squirrel glands that transform into a trampoline to help me go higher; I can use them with R2."); 
    }
    
}
