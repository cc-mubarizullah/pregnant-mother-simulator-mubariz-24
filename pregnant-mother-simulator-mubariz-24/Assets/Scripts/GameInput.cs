using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour
{
    [HideInInspector]
    public bool hasInteracted;
    public bool hasGrabbed;
    bool isInteractPressed;
    bool isGrabPressed;

    public static GameInput Instance;
    

    [Header("Player Inputs")]
    [SerializeField] Vector2 moveVector;
    [SerializeField] Vector2 lookVector;
    

    GameInputActions gameInputActions;

    private void Awake()
    {
        Instance = this;
        gameInputActions = new GameInputActions();
    }

    private void OnEnable()
    {
        gameInputActions.Player.Enable();
        gameInputActions.Player.Intract.performed += Intract_performed;
        gameInputActions.Player.Intract.canceled += Intract_canceled;
        gameInputActions.Player.Grab.performed += Grab_performed;
        gameInputActions.Player.Grab.canceled += Grab_canceled;
    }

    private void Intract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        isInteractPressed = true;
        hasInteracted = false;
    }

    private void Intract_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        isInteractPressed = false;

    }


    private void Grab_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        isGrabPressed = true;
        hasGrabbed = false;
    }
    private void Grab_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        isGrabPressed = false;
    }
   

    private void Update()
    {
        lookVector = gameInputActions.Player.Look.ReadValue<Vector2>();
        moveVector = gameInputActions.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetNormalizedMovementInXandZ()
    {
        return moveVector;
    }


    public Vector2 GetLookVector()
    { 
        return lookVector;
    }

    public bool InteractButtonPressed()
    {
        return isInteractPressed;   
    }

    public bool GrabButtonPressed()
    { 
    return isGrabPressed;
    }   

}
