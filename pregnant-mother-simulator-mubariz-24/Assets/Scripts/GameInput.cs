using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour
{
    [HideInInspector]
    public bool hasInteracted;
    public bool hasGrabbed;
    bool isInteractPressed;

    public static GameInput Instance;
    

    [Header("Player Inputs")]
    [SerializeField] Vector2 moveVector;
    

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

    private void Update()
    {
        moveVector = gameInputActions.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetNormalizedMovementInXandZ()
    {
        return moveVector;
    }
    public bool InteractButtonPressed()
    {
        return isInteractPressed;   
    }


}
