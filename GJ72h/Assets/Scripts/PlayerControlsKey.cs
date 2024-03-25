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
    
    [field: SerializeField] public GamepadControls fistAttackKeyGamepad { get; private set; }  = GamepadControls.buttonWest;
    [field: SerializeField] public GamepadControls legAttackKeyGamepad { get; private set; }  = GamepadControls.buttonSouth;
    [field: SerializeField] public GamepadControls BlockKeyGamepad { get; private set; }  = GamepadControls.buttonEast;
    [field: SerializeField] public GamepadControls UltimateKeyGamepad { get; private set; }  = GamepadControls.buttonNorth;
    [field: SerializeField] public GamepadControls StartKeyGamepad { get; private set; }  = GamepadControls.startButton;
    
    
    [field: Header("Player One Keys")]
    [field: SerializeField] public KeyCode UpKeyPlayerOne { get; private set; }  = KeyCode.Z;
    [field: SerializeField] public KeyCode leftKeyPlayerOne { get; private set; }  = KeyCode.Q;
    [field: SerializeField] public KeyCode DownKeyPlayerOne { get; private set; }  = KeyCode.S;
    [field: SerializeField] public KeyCode RightKeyPlayerOne { get; private set; }  = KeyCode.D;

    [field: SerializeField] public KeyCode fistAttackKeyPlayerOne { get; private set; }  = KeyCode.F;
    [field: SerializeField] public KeyCode legAttackKeyPlayerOne { get; private set; }  = KeyCode.G;
    [field: SerializeField] public KeyCode BlockKeyPlayerOne { get; private set; }  = KeyCode.V;
    [field: SerializeField] public KeyCode UltimateKeyPlayerOne { get; private set; }  = KeyCode.B;
    [field: SerializeField] public KeyCode StartKeyPlayerOne { get; private set; }  = KeyCode.Space;


    [field: Header("Player Two Keys")]
    [field: SerializeField]
    public KeyCode UpKeyPlayerTwo { get; private set; } = KeyCode.UpArrow;
    [field: SerializeField] public KeyCode leftKeyPlayerTwo { get; private set; } = KeyCode.LeftArrow;
    [field: SerializeField] public KeyCode DownKeyPlayerTwo { get; private set; } = KeyCode.DownArrow;
    [field: SerializeField] public KeyCode RightKeyPlayerTwo { get; private set; } = KeyCode.RightArrow;

    [field: SerializeField] public KeyCode fistAttackKeyPlayerTwo { get; private set; }  = KeyCode.I;
    [field: SerializeField] public KeyCode legAttackKeyPlayerTwo { get; private set; } = KeyCode.O;
    [field: SerializeField] public KeyCode BlockKeyPlayerTwo { get; private set; }  = KeyCode.K;
    [field: SerializeField] public KeyCode UltimateKeyPlayerTwo { get; private set; }  = KeyCode.L;
    [field: SerializeField] public KeyCode StartKeyPlayerTwo { get; private set; }  = KeyCode.Return;

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
