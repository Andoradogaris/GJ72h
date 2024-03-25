using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class ProcessControls : MonoBehaviour
{
    [field: SerializeField] public bool controlsEnable { get; private set; } = true;
    [field:Header("Properties")]
    [field: SerializeField] public int playerIndex { get; private set; }

    public float deadZoneOne;
    public float deadZoneTwo;

    //[field: SerializeField] public bool isRunningKeyPressed { get; private set; }
    
    [Header("Server authoritative inputs")]
    [SerializeField] bool isRunningKeyPressed;
    [SerializeField] bool isJumpKeyPressed;
    [SerializeField] bool isCrouchKeyPressed ;


    [Header("Client authoritative inputs")]
    [SerializeField] float horizontalInput;

    [SerializeField] float verticalInput;

    [SerializeField] bool isFistAtkPressed;

    [SerializeField] bool isLegAtkPressed;

    [SerializeField] bool isBlockKeyPressed;

    [SerializeField] bool isUltimateKeyPressed;

    [SerializeField] bool isStartKeyPressed;

    [SerializeField] bool isDashKeyPressed;

    
    
    [field: SerializeField] public Gamepad currentGamepad { get; private set; }
    
    private Dictionary<MoveDirection, float> inputs = new Dictionary<MoveDirection, float>();
    
    public float doubleTapInterval = 0.3f; // Intervalle de temps pour détecter le double-tap
    public float inputThreshold = 0.75f; // Seuil pour considérer l'input comme significatif

    MoveDirection currentMoveDirection;
    MoveDirection oldMoveDirection;


    const int DEVICE_NOT_CONNECTED_ID = -99999;
    public int currentGamepadId = DEVICE_NOT_CONNECTED_ID;
    public int keyboardIndex = 0;

    public int oldGamepadId;

    float doublestickTimer;
    float doublestickMaxTime;
    
    UnityEngine.InputSystem.Utilities.ReadOnlyArray<Gamepad> allGamepads;

    
    private void Update()
    {
        if (!controlsEnable) return;
        allGamepads = Gamepad.all;
        isDashKeyPressed = false;
        ProcessInputs();
        ProcessDashInput();


        isRunningKeyPressed = (horizontalInput > deadZoneOne || horizontalInput < -deadZoneOne);
        isJumpKeyPressed = (verticalInput > deadZoneOne);
        isCrouchKeyPressed = (verticalInput < -deadZoneOne);

        oldMoveDirection = currentMoveDirection;
    }

    private void ProcessInputs()
    {
        // Pour le moment c'est que clavier
        ProcessKeyboardInputPlayerOne();
        /*
        if (currentGamepad != null)
        {
            ProcessGamepadInput(currentGamepad);
        } else
        {
            if (keyboardIndex == 1)
            {
                ProcessKeyboardInputPlayerOne();
            } else if (keyboardIndex == 2)
            {
                ProcessKeyboardInputPlayerTwo();
            }

        }
        */
    }
    
    private void ProcessGamepadInput(Gamepad gamepad)
    {
        horizontalInput = gamepad.leftStick.x.ReadValue();
        verticalInput = gamepad.leftStick.y.ReadValue();

        isFistAtkPressed = WasButtonPressedThisFrame(PlayerControlsKey.Instance.fistAttackKeyGamepad, gamepad);
        isLegAtkPressed = WasButtonPressedThisFrame(PlayerControlsKey.Instance.legAttackKeyGamepad, gamepad);
        isUltimateKeyPressed = WasButtonPressedThisFrame(PlayerControlsKey.Instance.UltimateKeyGamepad, gamepad);
        isBlockKeyPressed = IsButtonPressed(PlayerControlsKey.Instance.BlockKeyGamepad, gamepad);
        isStartKeyPressed = WasButtonPressedThisFrame(PlayerControlsKey.Instance.StartKeyGamepad, gamepad);
    }
    
    bool WasButtonPressedThisFrame(GamepadControls buttonToCheck, Gamepad gamepad)
    {
        string buttonName = buttonToCheck.ToString();
        var property = gamepad.GetType().GetProperty(buttonName);
        if (property != null)
        {
            var button = (ButtonControl)property.GetValue(gamepad);
            return button.wasPressedThisFrame;
        }
        else
        {
            //Debug.Log("Button not found");
            return false;
        }
    }
    
    bool IsButtonPressed(GamepadControls buttonToCheck, Gamepad gamepad)
    {
        string buttonName = buttonToCheck.ToString();
        var property = gamepad.GetType().GetProperty(buttonName);
        if (property != null)
        {
            var button = (ButtonControl)property.GetValue(gamepad);
            return button.isPressed;
        }
        else
        {
            //Debug.Log("Button not found");
            return false;
        }
    }

    private void ProcessKeyboardInputPlayerOne()
    {
        int tempInput = 0;
        if (Input.GetKey(PlayerControlsKey.Instance.UpKeyPlayerOne))
        {
            tempInput += 1;
        }
        if (Input.GetKey(PlayerControlsKey.Instance.DownKeyPlayerOne))
        {
            tempInput -= 1;
        }
        verticalInput = tempInput;
        
        tempInput = 0;
        if (Input.GetKey(PlayerControlsKey.Instance.RightKeyPlayerOne))
        {
            tempInput += 1;
        }
        if (Input.GetKey(PlayerControlsKey.Instance.leftKeyPlayerOne))
        {
            tempInput -= 1;
        }
        horizontalInput = tempInput;
        
        isFistAtkPressed = Input.GetKeyDown(PlayerControlsKey.Instance.fistAttackKeyPlayerOne);
        isLegAtkPressed = Input.GetKeyDown(PlayerControlsKey.Instance.legAttackKeyPlayerOne);
        isBlockKeyPressed = Input.GetKey(PlayerControlsKey.Instance.BlockKeyPlayerOne);
        isUltimateKeyPressed = Input.GetKeyDown(PlayerControlsKey.Instance.UltimateKeyPlayerOne);
        isStartKeyPressed = Input.GetKeyDown(PlayerControlsKey.Instance.StartKeyPlayerOne);
    }

    public void SetGamepad(Gamepad newGamepad)
    {
        currentGamepad = newGamepad;
    }

    private void ProcessKeyboardInputPlayerTwo()
    {
        int tempInput = 0;
        if (Input.GetKey(PlayerControlsKey.Instance.UpKeyPlayerTwo))
        {
            tempInput += 1;
        }
        if (Input.GetKey(PlayerControlsKey.Instance.DownKeyPlayerTwo))
        {
            tempInput -= 1;
        }
        verticalInput = tempInput;
        
        tempInput = 0;
        if (Input.GetKey(PlayerControlsKey.Instance.RightKeyPlayerTwo))
        {
            tempInput += 1;
        }
        if (Input.GetKey(PlayerControlsKey.Instance.leftKeyPlayerTwo))
        {
            tempInput -= 1;
        }
        horizontalInput = tempInput;

        isFistAtkPressed = Input.GetKeyDown(PlayerControlsKey.Instance.fistAttackKeyPlayerTwo);
        isLegAtkPressed = Input.GetKeyDown(PlayerControlsKey.Instance.legAttackKeyPlayerTwo);
        isBlockKeyPressed = Input.GetKey(PlayerControlsKey.Instance.BlockKeyPlayerTwo);
        isUltimateKeyPressed = Input.GetKeyDown(PlayerControlsKey.Instance.UltimateKeyPlayerTwo);
        isStartKeyPressed = Input.GetKeyDown(PlayerControlsKey.Instance.StartKeyPlayerTwo);
    }

    public void SetDeadZone(float newDeadZone)
    {
        deadZoneOne = newDeadZone;
    }

    private void ProcessDashInput()
    {
        if (horizontalInput > inputThreshold)
        {
            currentMoveDirection = MoveDirection.Right;
        }
        else if (horizontalInput <  -inputThreshold)
        {
            currentMoveDirection = MoveDirection.Left;
        }
        else
        {
            currentMoveDirection = MoveDirection.None;
        }

        // Si l'input horizontal est significatif, stockez-le
        if (currentMoveDirection != oldMoveDirection)
        {
            if (currentMoveDirection != MoveDirection.None && inputs.ContainsKey(currentMoveDirection))
            {
                inputs.Clear();
                isDashKeyPressed = true;
            }
            else
            {
                inputs[currentMoveDirection] = Time.time;
            }
        }

        if (inputs.ContainsKey(MoveDirection.Left) && Time.time - inputs[MoveDirection.Left] > doubleTapInterval)
        {
            inputs.Remove(MoveDirection.Left);
        }
        if (inputs.ContainsKey(MoveDirection.Right) && Time.time - inputs[MoveDirection.Right] > doubleTapInterval)
        {
            inputs.Remove(MoveDirection.Right);
        }
        if (inputs.ContainsKey(MoveDirection.None) && Time.time - inputs[MoveDirection.None] > doubleTapInterval)
        {
            inputs.Remove(MoveDirection.None);
        }
    }

    public void ToggleControls(bool state)
    {
        controlsEnable = state;
        isRunningKeyPressed = false;
        isJumpKeyPressed = false;
        isCrouchKeyPressed = false;
        horizontalInput = 0;
        verticalInput = 0;
        isFistAtkPressed = false;
        isLegAtkPressed = false;
        isBlockKeyPressed = false;
        isUltimateKeyPressed = false;
        isStartKeyPressed = false;
        isDashKeyPressed = false;
    }
    
    private enum MoveDirection
    {
        Left,
        None,
        Right,
    }

    public bool GetIsFistAtkPressed()
    {
        return isFistAtkPressed;
    }

    public bool GetIsLegAtkPressed()
    {
        return isLegAtkPressed;
    }

    public bool GetIsBlockPressed()
    {
        return isBlockKeyPressed;
    }

    public float GetHorizontalInput()
    {
        return horizontalInput;
    }
    
    public float GetVerticalInput()
    {
        return verticalInput;
    }

    public bool GetIsBlockKeyPressed()
    {
        return isBlockKeyPressed;
    }

    public bool GetIsCrouchKeyPressed()
    {
        return isCrouchKeyPressed;
    }

    public bool GetIsStartKeyPressed()
    {
        return isStartKeyPressed;
    }

    public bool GetIsRunningKeyPressed()
    {
        return isRunningKeyPressed;
    }

    public bool GetIsUltimateKeyPressed()
    {
        return isUltimateKeyPressed;
    }

    public bool GetIsJumpKeyPressed()
    {
        return isJumpKeyPressed;
    }

    public bool GetIsDashKeyPressed()
    {
        return isDashKeyPressed;
    }
    

}
