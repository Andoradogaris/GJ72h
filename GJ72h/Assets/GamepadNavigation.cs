using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadNavigation : MonoBehaviour
{
    public MenuGamepad menuGamepad;
    public ProcessControls menuProcessControls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (menuProcessControls.GetVerticalInput() > 0)
        {
            menuGamepad.SelectionButton(0);
        } else if (menuProcessControls.GetVerticalInput() < 0)
        {
            menuGamepad.SelectionButton(1);
        }
    }
}
