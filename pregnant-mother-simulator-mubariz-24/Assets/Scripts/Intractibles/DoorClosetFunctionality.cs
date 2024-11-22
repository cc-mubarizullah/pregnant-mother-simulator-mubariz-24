using Unity.VisualScripting;
using UnityEngine;

public class DoorClosetFunctionality : IIntractShowVisuals, IInteractWithIneractables
{
    bool hasDrawerOpen;
    bool isInteracting;
    bool isDoorOpen;
    const string openDoorText = "Open Door!";
    const string closeDoorText = "Close Door!";
    float rotationValue = 90f;
    Vector3 closeRotationOfDoor;
    Vector3 openRotationOfDoor;
    float elapsedTime;
    float maxTimeToOpenDoor = 1f;
    enum PositiveOrNegative
    {
        Positive,
        Negative
    }
    
    [SerializeField] PositiveOrNegative positiveOrNegative;
    [SerializeField] AudioClip doorOpenEffect;
    [SerializeField] AudioClip doorCloseEffect;


    private void Start()
    {
        closeRotationOfDoor = transform.localEulerAngles;   // to set close door position to the door's position at the start of the game
        UpdateOpenPositionOfDoor();                         // to update the target Rotation of door only at the first frame
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
        }
    }

    void CloseDoorAnimation()
    {
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / maxTimeToOpenDoor;
        transform.localEulerAngles = Vector3.Slerp(openRotationOfDoor, closeRotationOfDoor, t);

        if (t >= 1f)
        {
            elapsedTime = 0f;
            isInteracting = false;
        }
    }


    // this function will add or subtract 90 degree from the targetRotation(OpenRotationOfDoor) for correct opening
    void UpdateOpenPositionOfDoor()
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
    }

    public void Interact()
    {
        ShowItemText();
    }
    public override void ShowItemText()
    {
        InteractiveItemTextUI.Instance.SetItemText(OpenCloseText());
    }

    string OpenCloseText()
    {
        if (!isDoorOpen)
        {
            return openDoorText;
        }
        else
        {
            return closeDoorText;
        }
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
            VfxManagers.Instance.PlaySoundEffect(doorOpenEffect, gameObject.transform.position);
            hasDrawerOpen = true;
        }
        else
        {
            VfxManagers.Instance.PlaySoundEffect(doorCloseEffect, gameObject.transform.position);
            hasDrawerOpen = false;
        }
    }
}
