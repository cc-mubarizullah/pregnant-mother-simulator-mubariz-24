using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class DoorFunctionality : IIntractShowVisuals, IInteractWithIneractables 
{
    readonly string doorOpenText = "Open Door!";
    readonly string doorCloseText = "Close Door!";

    const string OPEN_DOOR = "Open";

    bool isOpen;
    Animator animator;
    public void Start()
    {
        isOpen = false;
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
        if (isOpen)
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
        if (!isOpen)
        {
        isOpen = true;
        animator.SetBool(OPEN_DOOR, true);
        }
        else
        {
        isOpen = false;
        animator.SetBool(OPEN_DOOR, false);
        }
    }
        
}

