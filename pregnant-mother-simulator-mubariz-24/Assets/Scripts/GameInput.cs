using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour
{
    [HideInInspector]
    public bool hasInteracted;
    bool isInteractPressed;

    public static GameInput Instance;

    //public event EventHandler OnIntract;
    

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
    }

    private void Intract_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        isInteractPressed = false;

    }

    private void Intract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        isInteractPressed = true;
        hasInteracted = false;
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

}
