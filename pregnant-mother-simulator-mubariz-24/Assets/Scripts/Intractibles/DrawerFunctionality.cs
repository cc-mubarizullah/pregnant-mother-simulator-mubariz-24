using UnityEngine;

public class DrawerFunctionality : IIntractShowVisuals, IInteractWithIneractables
{
    readonly string doorOpenText = "Open Drawer.";
    readonly string doorCloseText = "Close Drawer.";

    [Tooltip("The DIFFERENCE between present local position and targer local position.")]
    [SerializeField] float openCloseDiff = 0.41f;

    enum AxisToAnimate
    {
        XAxis,
        YAxis,  
        ZAxis
    }

    [SerializeField] AxisToAnimate axisToAnimate;

    Vector3 openTargetPosition;
    Vector3 closeTargetPosition;
    bool isDrawerOpen = true;
    float elapsedTime = 0f;
    float timeForDrawerMovement = 1f;
    bool isInteracting = false;

    private void Start()
    {
        UpdateOpenDrawerTargetVector3();
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

    

    public void Interact()
    {
        ShowItemText();
    }

    public void PhysicalInteract()
    {
        elapsedTime = 0f;
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

    void DrawerOpenAnimation()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / timeForDrawerMovement);
        transform.localPosition = Vector3.Lerp(transform.localPosition, openTargetPosition, t);

        if (t >= 1f)
        {
            elapsedTime = 0f;
            isInteracting = false;
        }
    }
    void DrawerCloseAnimation()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01( elapsedTime / timeForDrawerMovement);
        transform.localPosition = Vector3.Lerp(transform.localPosition, closeTargetPosition, t);

        if (t >= 1f)
        {
            elapsedTime = 0f;
            isInteracting = false;
        }
    }


    void UpdateOpenDrawerTargetVector3()
    {
        openTargetPosition = transform.localPosition;
        switch (axisToAnimate)
        {
            case AxisToAnimate.XAxis:
                openTargetPosition.x += openCloseDiff;
                break;
            case AxisToAnimate.YAxis:
                openTargetPosition.y += openCloseDiff;
                break;
            case AxisToAnimate.ZAxis:
                openTargetPosition.z += openCloseDiff;
                break;
        }
       
    }
}
