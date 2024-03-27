using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MenuGamepad : MonoBehaviour
{
    public ProcessControls menuProcessControls;
    
    public Button[] buttons;
    
    public GameObject pauseMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        SelectionButton(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseMenu.activeSelf)
        {
            return;
        }
        if (menuProcessControls.GetIsJumpKeyPressed())
        {
            clickButton();
        }
    }
    
    public void SelectionButton(int index)
    {
        buttons[index].Select();
        if (EventSystem.current == null)
        {
            Debug.Log("EventSystem is null");
            return;
        }
        EventSystem.current.SetSelectedGameObject(buttons[index].gameObject);
    }
    
    void clickButton()
    {
        if (EventSystem.current == null)
        {
            Debug.Log("EventSystem is null");
            return;
        }
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            Debug.Log("currentSelectedGameObject is null");
            return;
        }
        if (EventSystem.current.currentSelectedGameObject.GetComponent<Button>() == null)
        {
            Debug.Log("Button is null");
            return;
        }
        EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
            
    }
}
