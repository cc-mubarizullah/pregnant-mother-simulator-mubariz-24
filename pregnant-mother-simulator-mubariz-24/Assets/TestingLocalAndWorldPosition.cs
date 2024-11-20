using UnityEngine;

public class TestingLocalAndWorldPosition : IIntractShowVisuals, IInteractWithIneractables
{
    readonly string doorOpenText = "Open Drawer.";
    readonly string doorCloseText = "Close Drawer.";

    float openCloseDiff = 0.4103f;
    Vector3 openTargetPosition;
    Vector3 closeTargetPosition;
    bool isDrawerOpen;
    float elapsedTime = 0f;
    float timeForDrawerMovement = 1f;
    bool isInteracting = false;

    private void Start()
    {
        UpdateOpenTargetVector3();
        closeTargetPosition = transform.localPosition;
    }
    private void Update()
    {
        if (isInteracting)
        {
            if (!isDrawerOpen)
            {
                DrawerOpenAnimation();
            }
            else
            {
                DrawerCloseAnimation();
            }
        }
    }
    
    void DrawerOpenAnimation()
    {
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / timeForDrawerMovement;
        transform.localPosition = Vector3.Lerp(transform.localPosition, openTargetPosition, t);

        if (transform.localPosition == openTargetPosition)
        {
            elapsedTime = 0f;
        }
    }
    void DrawerCloseAnimation()
    {
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / timeForDrawerMovement;
        transform.localPosition = Vector3.Lerp(transform.localPosition, closeTargetPosition, t);

        if (transform.localPosition == closeTargetPosition)
        {
            elapsedTime = 0f;
        }
    }


    void UpdateOpenTargetVector3()
    {
        openTargetPosition = transform.localPosition;
        openTargetPosition.z += openCloseDiff;
    }
    void UpdateCloseTargetVector3()
    {
        closeTargetPosition = transform.localPosition;
        closeTargetPosition.z -= openCloseDiff;
    }

    public void Interact()
    {
        ShowItemText();
    }

    public void PhysicalInteract()
    {
        isInteracting = true;
        if (isDrawerOpen)
        {
            isDrawerOpen = false;
        }
        else
        {
            isDrawerOpen = true;
        }
    }
    public override void ShowItemText()
    {
        InteractiveItemTextUI.Instance.SetItemText(OpenCloseText());
    }

    string OpenCloseText()
    {
        if (!isDrawerOpen)
        {
            return doorCloseText;
        }
        else
        {
            return doorOpenText;
        }
    }
}
