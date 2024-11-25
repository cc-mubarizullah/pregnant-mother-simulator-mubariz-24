using Unity.VisualScripting;
using UnityEngine;

public class DoorClosetFunctionality : IIntractShowVisuals, IInteractWithIneractables
{
    bool hasDrawerOpen = true;
    bool isInteracting;
    bool isDoorOpen = true;
    const string openDoorText = "Open Door!";
    const string closeDoorText = "Close Door!";
    float rotationValue = 90f;
    Vector3 closeRotationOfDoor;
    Vector3 openRotationOfDoor;
    Vector3 currentRotationOfDoor;
    float elapsedTime;
    float maxTimeToOpenDoor = 0.5f;
    float maxTimeToCloseDoor = 0.5f;
    enum PositiveOrNegative
    {
        Positive,
        Negative
    }
    
    [SerializeField] PositiveOrNegative positiveOrNegative;
    


    private void Start()
    {
        closeRotationOfDoor = transform.localEulerAngles;        // to set close door position to the door's position at the start of the game
        UpdateOpenPositionOfDoorStart();                         // to update the target Rotation of door only at the first frame
    }
    private void Update()
    {
        if (isInteracting)
        {
            if (!isDoorOpen)
            {
                OpenDoorAnimation();
            }
            else
            {
                CloseDoorAnimation();
            }
        }
    }
    public void Interact()
    {
        ShowItemText();
    }
    public override void ShowItemText()
    {
        InteractiveItemTextUI.Instance.SetItemText(OpenCloseText());
    }

    public void PhysicalInteract()
    {
        elapsedTime = 0f;
        isInteracting = true;
        if (isDoorOpen)
        {
            isDoorOpen = false;
        }
        else
        {
            isDoorOpen = true;
        }

        // the upper lines will reverse the action for opening or closing door every time player physically interact with the gameobject



        if (!hasDrawerOpen)
        {
            SFXmanager.Instance.PlaySoundEffectOnPosition(SFXmanager.Instance.doorCloseSFX, gameObject.transform.position);
            hasDrawerOpen = true;
        }
        else
        {
            SFXmanager.Instance.PlaySoundEffectOnPosition(SFXmanager.Instance.doorOpenSFX, gameObject.transform.position);
            hasDrawerOpen = false;
        }
    }

    //elapsed time will be equal to the time each frame take to execute and then it will be divided by our max time and then will be use as rotation degree in slerp
    void OpenDoorAnimation()
    {
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / maxTimeToOpenDoor;
        transform.localEulerAngles = Vector3.Slerp(closeRotationOfDoor, openRotationOfDoor,t);

        if (t >= 1f)
        {
            elapsedTime = 0f;
            isInteracting = false;
            isDoorOpen=false;
        }
    }

    void CloseDoorAnimation()
    {
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / maxTimeToCloseDoor;
        transform.localEulerAngles = Vector3.Slerp(openRotationOfDoor, closeRotationOfDoor, t);

        if (t >= 1f)
        {
            elapsedTime = 0f;
            isInteracting = false;
            isDoorOpen = true;
        }
    }


    // this function will add or subtract 90 degree from the targetRotation(OpenRotationOfDoor) for correct opening
    void UpdateOpenPositionOfDoorStart()
    {
        switch (positiveOrNegative)
        {
            case PositiveOrNegative.Positive:
                openRotationOfDoor.y += rotationValue;
                break;
            case PositiveOrNegative.Negative:
                openRotationOfDoor.y -= rotationValue;
                break;

        }
    }  // working correctly



    string OpenCloseText()
    {
        if (!isDoorOpen)
        {
            return closeDoorText;
        }
        else
        {
            return openDoorText;
        }
    }


}
