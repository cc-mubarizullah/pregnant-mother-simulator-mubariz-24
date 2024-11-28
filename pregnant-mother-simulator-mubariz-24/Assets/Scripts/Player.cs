using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.Touch;


[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public static event EventHandler<OnIntractEventArgs> OnIntract;

    public class OnIntractEventArgs : EventArgs
    {
        public bool intracting;
    }


    [Header("Essentials")]

    [Tooltip("The GameInput script that should be attached with some gameobject as this script should be reading input for look and movment from it.")]
    [SerializeField] GameInput gameInput;

    [SerializeField] CharacterController characterController;

    [Tooltip("This game object should have a collider with apprx 0.3 unit radius")]
    [SerializeField] GameObject groundCheck;

    [Tooltip("The gameobject which controlls the cinemachine position and raycasitg for interaction.")]
    [SerializeField] GameObject cameraRootGameobject;

    [Tooltip("The position where object will move for grab or interaction animation")]
    [SerializeField] Transform grabPoint;

    [Tooltip("The layer on which player can jump.")]
    [SerializeField] LayerMask groundLayer;

    [Space(20)]
    [Header("Prefrences")]
    [SerializeField] float playerSpeed = 5f;

    [SerializeField] float cameraRotationSpeed = 1f;

    [SerializeField] float gravity = -1f;
    
    [Tooltip("How far a player can interact with Objects.")]
    [SerializeField] float distanceOfRaycast = 1.6f;
    
    [Tooltip("The layer of gameobjects with which player can interact.")]
    [SerializeField] LayerMask interactLayer;


    [Space(30)]
    [SerializeField] bool lookWithMouse;

    float cameraTopClamp = 90f;
    float cameraButtomClamp = -90f;
    float thresholdOrDeadZone = 0.01f;
    private float cinemachineTargetPitch;
    private float rotationVelocity;
    float mealEatenTimer;
    bool canInteract = true;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("there are more than one instance of player");
        Instance = this;

    }

    private void Update()
    {
        Movement();
        RaycastingForInteractbles();
    }

    private void LateUpdate()
    {
        CameraRotation();
    }

    public void Movement()
    {
        float groundCheckRadius = 0.25f;
        bool isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundCheckRadius, groundLayer);  //ground check

        Vector2 movInXandZ = gameInput.GetNormalizedMovementInXandZ();

        Vector3 movement = transform.right * movInXandZ.x + transform.forward * movInXandZ.y;    // transform.right and transform.forward are the directions according to the player direction, not of world

        movement.y = isGrounded ? 0f : gravity;

        characterController.Move(playerSpeed * Time.deltaTime * movement);
    }

    private void CameraRotationLogic()
    {
        if (gameInput.GetLookVector().sqrMagnitude >= thresholdOrDeadZone)
        {
            cinemachineTargetPitch += gameInput.GetLookVector().y * cameraRotationSpeed;       // ..FOR CAMERA UP ROTATION..set variable for y component of look vector2
            rotationVelocity = gameInput.GetLookVector().x * cameraRotationSpeed;                               // ..FOR CAMERA SIDE WAYS ROTATION..set variable for x component of look vector2

            // now clamping the up rotation
            cinemachineTargetPitch = Mathf.Clamp(cinemachineTargetPitch, cameraButtomClamp, cameraTopClamp);

            // updating cinemachine target pitch
            cameraRootGameobject.transform.localRotation = Quaternion.Euler(cinemachineTargetPitch, 0f, 0f);

            // updating player rotation according to the rotationVelocity
            transform.Rotate(Vector3.up * rotationVelocity);
        }
    }

    public void CameraRotation()
    {
        if (lookWithMouse)
        {
            CameraRotationLogic();
        }
        else if (IsTouchedAtLeftSide())
        {
            CameraRotationLogic();
        }
    }

    public bool IsTouchedAtLeftSide()
    {
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Check if the touch is in the left two-thirds of the screen
            if (touch.position.x < 2 * (Screen.width) / 3)
            {
                // Allow rotation when the touch begins, moves, or is stationary
                return touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary;
            }
        }
        return false;
    }

    private void RaycastingForInteractbles()
    {
        if (canInteract)
        {
            Ray ray = new Ray(cameraRootGameobject.transform.position, cameraRootGameobject.transform.forward);

            bool hasHitInterectables = Physics.Raycast(ray, out RaycastHit hitInfo, distanceOfRaycast, interactLayer);

            if (hasHitInterectables)
            {
                IInteractWithIneractables interactable = hitInfo.collider.GetComponent<IInteractWithIneractables>(); // get the interface of interactables items
                if (interactable != null)
                {
                    // INTERACTION HERE
                    OnIntract?.Invoke(this, new OnIntractEventArgs { intracting = true });
                    interactable.Interact();

                    if (gameInput.InteractButtonPressed() && !gameInput.hasInteracted)
                    {
                        // PHYSICAL INTERACTION HERE
                        interactable.PhysicalInteract();
                        gameInput.hasInteracted = true;
                    }
                    IInventoryHandler grabAble = hitInfo.collider.GetComponent<IInventoryHandler>();
                    if (grabAble != null)
                    {
                        if (gameInput.GrabButtonPressed() && !gameInput.hasGrabbed)
                        {
                            // GRAB INTERACTION HERE
                            grabAble.Grab();
                            gameInput.hasInteracted = true;
                        }
                    }

                }

            }
            else
            {
                OnIntract?.Invoke(this, new OnIntractEventArgs { intracting = false });
            }
        }
    }

    public Vector3 GetGrabPosition()
    {
        return grabPoint.position;
    }
}
