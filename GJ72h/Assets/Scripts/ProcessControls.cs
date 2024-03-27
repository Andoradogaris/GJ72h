using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Serialization;

public class ProcessControls : MonoBehaviour
{
    [field: SerializeField] public bool controlsEnable { get; private set; } = true;
    [field:Header("Properties")]
    public float deadZoneOne;

    [SerializeField] float horizontalInput;
    [SerializeField] float verticalInput;

    [SerializeField] float cameraHorizontalInput;
    [SerializeField] float cameraVerticalInput;
    [SerializeField] float mouseSensitivity = 800f;
    [SerializeField] float gamepadSensitivity = 300f;

    [SerializeField] bool isInteractPressed;

    [SerializeField] bool isJumpPressed;
    [SerializeField] bool isJumpHold;
    [SerializeField] bool isTrampolineKeyPressed;


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
    public int keyboardIndex = 1;

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

        oldMoveDirection = currentMoveDirection;
    }

    private void ProcessInputs()
    {
        // Pour le moment c'est que clavier
        //ProcessKeyboardInputPlayerOne();
        
        if (currentGamepad != null)
        {
            ProcessGamepadInput(currentGamepad);
        } else
        {
            ProcessKeyboardInputPlayerOne();
        }
    }
    
    float oldRightStickX = -9999;
    float oldRightStickY = -9999;
    private void ProcessGamepadInput(Gamepad gamepad)
    {
        if (oldRightStickX == -9999)
        {
            oldRightStickX = gamepad.rightStick.x.ReadValue();
            oldRightStickY = gamepad.rightStick.y.ReadValue();
        }
        horizontalInput = gamepad.leftStick.x.ReadValue();
        verticalInput = gamepad.leftStick.y.ReadValue();

        float rightStickX = gamepad.rightStick.x.ReadValue();
        float rightStickY = gamepad.rightStick.y.ReadValue();
        
        float xDiff = rightStickX - oldRightStickX;
        float yDiff = rightStickY - oldRightStickY;
        
        cameraHorizontalInput = rightStickX * gamepadSensitivity * Time.deltaTime;
        cameraVerticalInput = rightStickY * gamepadSensitivity * Time.deltaTime;
        
        isInteractPressed = WasButtonPressedThisFrame(PlayerControlsKey.Instance.interactKeyGamepad, gamepad);
        isJumpPressed = WasButtonPressedThisFrame(PlayerControlsKey.Instance.legAttackKeyGamepad, gamepad);
        isJumpHold = IsButtonPressed(PlayerControlsKey.Instance.legAttackKeyGamepad, gamepad);
        
        isTrampolineKeyPressed = WasButtonPressedThisFrame(PlayerControlsKey.Instance.TrampolineKeyGamepad, gamepad);
        isStartKeyPressed = WasButtonPressedThisFrame(PlayerControlsKey.Instance.StartKeyGamepad, gamepad);

        oldRightStickX = rightStickX;
        oldRightStickY = rightStickY;
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
        
        cameraHorizontalInput = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        cameraVerticalInput = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        isInteractPressed = Input.GetKeyDown(PlayerControlsKey.Instance.interactKeyPlayerOne);
        isJumpPressed = Input.GetKeyDown(PlayerControlsKey.Instance.jumpKeyPlayerOne);
        isJumpHold = Input.GetKey(PlayerControlsKey.Instance.jumpKeyPlayerOne);
        isTrampolineKeyPressed = Input.GetKeyDown(PlayerControlsKey.Instance.TrampolineKeyPlayerOne);
        isStartKeyPressed = Input.GetKeyDown(PlayerControlsKey.Instance.StartKeyPlayerOne);
        
    }

    public void SetGamepad(Gamepad newGamepad)
    {
        currentGamepad = newGamepad;
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
        horizontalInput = 0;
        verticalInput = 0;
        isInteractPressed = false;
        isJumpPressed = false;
        isJumpHold = false;
        isTrampolineKeyPressed = false;
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
        return isInteractPressed;
    }

    public bool GetIsJumpKeyPressed()
    {
        return isJumpPressed;
    }
    
    public bool GetIsJumpKeyHold()
    {
        return isJumpHold;
    }

    public float GetHorizontalInput()
    {
        return horizontalInput;
    }
    
    public float GetVerticalInput()
    {
        return verticalInput;
    }
    
    public float GetCameraHorizontalInput()
    {
        return cameraHorizontalInput;
    }
    
    public float GetCameraVerticalInput()
    {
        return cameraVerticalInput;
    }
    
    public bool GetIsTrampolineKeyPressed()
    {
        return isTrampolineKeyPressed;
    }

    public bool GetIsStartKeyPressed()
    {
        return isStartKeyPressed;
    }
    
    public bool GetIsDashKeyPressed()
    {
        return isDashKeyPressed;
    }
    

}
