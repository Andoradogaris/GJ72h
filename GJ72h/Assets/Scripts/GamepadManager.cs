using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class GamepadManager : MonoBehaviour
{
    protected const int DEVICE_NOT_CONNECTED_ID = -99999;
    public ProcessControls player1ctrl;

    bool gamepadOneFound = false;
    List<int> GamepadAvaible = new List<int>();
    
    void treatGamepadConnections()
    {
        gamepadOneFound = false;
        GamepadAvaible.Clear();
        for (int i = 0; i < Gamepad.all.Count; i++)
        {
            
            if (player1ctrl.currentGamepadId == Gamepad.all[i].deviceId)
            {
                gamepadOneFound = true;
            }
            else
            {
                GamepadAvaible.Add(i);
            }
        }

        if (!gamepadOneFound)
        {
            SetGamepadFor(player1ctrl);
        } 
        
    }
    
    void SetGamepadFor(ProcessControls playerControls)
    {
        if (GamepadAvaible.Count > 0)
        {
            playerControls.currentGamepadId = Gamepad.all[GamepadAvaible[0]].deviceId;
            playerControls.SetGamepad(Gamepad.all[GamepadAvaible[0]]);
            GamepadAvaible.RemoveAt(0);
        }
        else
        {
            playerControls.oldGamepadId = playerControls.currentGamepadId;
            playerControls.currentGamepadId = DEVICE_NOT_CONNECTED_ID;
        }
    }

    void Update()
    {
        treatGamepadConnections();
    }
}
