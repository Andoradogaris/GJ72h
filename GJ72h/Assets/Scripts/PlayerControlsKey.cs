using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlsKey : MonoBehaviour
{
    public static PlayerControlsKey Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    [field: Header("Gamepad Controls")]
    
    [field: SerializeField] public GamepadControls interactKeyGamepad { get; private set; }  = GamepadControls.buttonWest;
    [field: SerializeField] public GamepadControls legAttackKeyGamepad { get; private set; }  = GamepadControls.buttonSouth;
    [field: SerializeField] public GamepadControls TrampolineKeyGamepad { get; private set; }  = GamepadControls.rightTrigger;
    [field: SerializeField] public GamepadControls StartKeyGamepad { get; private set; }  = GamepadControls.startButton;
    
    
    [field: Header("Player One Keys")]
    [field: SerializeField] public KeyCode UpKeyPlayerOne { get; private set; }  = KeyCode.Z;
    [field: SerializeField] public KeyCode leftKeyPlayerOne { get; private set; }  = KeyCode.Q;
    [field: SerializeField] public KeyCode DownKeyPlayerOne { get; private set; }  = KeyCode.S;
    [field: SerializeField] public KeyCode RightKeyPlayerOne { get; private set; }  = KeyCode.D;

    [field: SerializeField] public KeyCode interactKeyPlayerOne { get; private set; }  = KeyCode.F;
    [field: SerializeField] public KeyCode jumpKeyPlayerOne { get; private set; }  = KeyCode.Space;
    [field: SerializeField] public KeyCode TrampolineKeyPlayerOne { get; private set; }  = KeyCode.V;
    [field: SerializeField] public KeyCode StartKeyPlayerOne { get; private set; }  = KeyCode.Escape;
    
}



public enum GamepadControls
{
    buttonSouth,
    buttonEast,
    buttonWest,
    buttonNorth,
    leftStickButton,
    rightStickButton,
    leftShoulder,
    rightShoulder,
    leftTrigger,
    rightTrigger,
    startButton,
}
