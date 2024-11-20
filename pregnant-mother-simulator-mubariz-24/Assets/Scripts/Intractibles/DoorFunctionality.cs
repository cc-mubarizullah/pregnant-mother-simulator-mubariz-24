using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorFunctionality : IIntractShowVisuals, IInteractWithIneractables 
{
    readonly string doorOpenText = "Open Door!";
    readonly string doorCloseText = "Close Door!";

    const string OPEN_DOOR = "IsOpen";

    bool isDoorOpen;
    Animator animator;
    public void Start()
    {
        isDoorOpen = false;
        animator = GetComponent<Animator>();
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
        if (isDoorOpen)
        {
            return doorCloseText;
        }
        else
        {
            return doorOpenText;
        }
    }

    public void PhysicalInteract()
    {
        Debug.Log("this message is from door");
        if (!isDoorOpen)
        {
        isDoorOpen = true;
        animator.SetBool(OPEN_DOOR, true);
        }
        else
        {
        isDoorOpen = false;
        animator.SetBool(OPEN_DOOR, false);
        }
    }
        
}

