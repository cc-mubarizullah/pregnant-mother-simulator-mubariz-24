using UnityEngine;

public class CamRotWithMouse : MonoBehaviour
{
    [Tooltip("The GameInput script that should be attached with some gameobject as this script should be reading input for look and movment from it.")]
    [SerializeField] GameInput gameInput;

    [Tooltip("The gameobject which controlls the cinemachine position and raycasitg for interaction.")]
    [SerializeField] GameObject cameraRootGameobject;

    [SerializeField] float cameraRotationSpeed = 1f;
    float cameraTopClamp = 90f;
    float cameraButtomClamp = -90f;
    float thresholdOrDeadZone = 0.01f;
    private float cinemachineTargetPitch;
    private float rotationVelocity;
    [Space(30)]
    [SerializeField] bool lookWithMouse;
    private void LateUpdate()
    {
        if (lookWithMouse)
        {
            CameraRotationWithMouse();
        }
    }

    private void CameraRotationWithMouse()
    {

        if (gameInput.GetLookVector().sqrMagnitude >= thresholdOrDeadZone)
        {
            Debug.Log("working");
            Debug.Log("working");
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
}
