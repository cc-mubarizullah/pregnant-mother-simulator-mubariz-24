using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    int leftFingerId; //for camera rotation
    int rightFingerId;

    float halfOfScreenWidth;

    [SerializeField] GameObject cameraRootGameObject;
    [SerializeField] float cameraSentivity;
    
    Vector2 lookInput;

    float cameraPitch;

    private void Start()
    {
        leftFingerId =-1;
        rightFingerId = -1;

        halfOfScreenWidth = Screen.width / 2;

        
    }
    private void Update()
    {
        GetTouchInput();

        if (leftFingerId != -1)
        {
            CameraRotation();
        }

    }

    private void GetTouchInput()
    {
        lookInput = Vector2.zero;
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);

            switch (t.phase)
            {
                case TouchPhase.Began:
                    if (t.position.x > halfOfScreenWidth && rightFingerId == -1)
                    {
                        rightFingerId = t.fingerId;
                    }
                    else if (t.position.x < halfOfScreenWidth && leftFingerId == -1)
                    {
                        leftFingerId = t.fingerId;
                    }
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    // get input for looking around
                    if (t.fingerId == leftFingerId)
                    {
                        lookInput = t.deltaPosition * cameraSentivity * Time.deltaTime;
                    }
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (t.fingerId == leftFingerId)
                    {
                        leftFingerId = -1;
                    }
                    else if (t.fingerId == rightFingerId)
                    {
                        rightFingerId = -1;
                    }
                    break;
                default:
                    break;
            }
        }

    }

    private void CameraRotation()
    {
        cameraPitch = Mathf.Clamp(cameraPitch - lookInput.y, -89f, 89f);
        cameraRootGameObject.transform.localRotation = Quaternion.Euler(cameraPitch, 0, 0);

        transform.Rotate(transform.up, lookInput.x);
    }
}
