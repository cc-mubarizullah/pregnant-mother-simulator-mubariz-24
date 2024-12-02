using UnityEngine;

public class UltrasoundCutsceneCamera : MonoBehaviour
{
    // will be used in animation
    // this method should only work at one frame and will shift player position to this camera position
    public void SetPlayerPositionAccToEndOfCamera()
    {
      
        Vector3 cameraPosition = transform.position;
        Player.Instance.transform.position = cameraPosition;
    }
}
