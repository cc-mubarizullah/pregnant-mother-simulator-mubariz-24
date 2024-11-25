using UnityEngine;

public class DrawerFunctionality : IIntractShowVisuals, IInteractWithIneractables
{
    readonly string doorOpenText = "Open Drawer.";
    readonly string doorCloseText = "Close Drawer.";

    [Tooltip("The DIFFERENCE between present local position and targer local position.")]
    [SerializeField] float openCloseDiff = 0.41f;

   
    bool hasDrawerOpen = false;             // when drawer animation runs at first frame it will be true after words after that we will make it value false so it does not play at second frame

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
    float timeForDrawerMovement = 0.5f;
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

    public override void ShowItemText()
    {
        InteractiveItemTextUI.Instance.SetItemText(OpenCloseText());
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

        if (!hasDrawerOpen)
        {
            SFXmanager.Instance.PlaySoundEffectOnPosition(SFXmanager.Instance.drawerOpenSFX, gameObject.transform.position);
            hasDrawerOpen = true;
        }
        else
        {
            SFXmanager.Instance.PlaySoundEffectOnPosition(SFXmanager.Instance.drawerCloseSFX, gameObject.transform.position);
            hasDrawerOpen= false;
        }
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
        float t = elapsedTime / timeForDrawerMovement;
        transform.localPosition = Vector3.Lerp(closeTargetPosition, openTargetPosition, t );

        if (t >= 1f)
        {
            elapsedTime = 0f;
            isInteracting = false;
        }
    }
    void DrawerCloseAnimation()
    {

        
        elapsedTime += Time.deltaTime;
        float t =  elapsedTime / timeForDrawerMovement;
        transform.localPosition = Vector3.Lerp(openTargetPosition, closeTargetPosition, t  );

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
