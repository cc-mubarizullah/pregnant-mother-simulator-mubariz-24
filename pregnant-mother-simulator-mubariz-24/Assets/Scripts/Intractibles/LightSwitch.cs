
using UnityEngine;

// this class is of interactables

public class LightSwitch : IIntractShowVisuals, IInteractWithIneractables 
{
    [SerializeField] IntractiblesSO intractiblesSO;

    public void Interact()
    {
        ShowItemText();
    }

    public void PhysicalInteract()
    {
        
    }

    public override void ShowItemText()
    {
        InteractiveItemTextUI.Instance.SetItemTextFromSO(intractiblesSO);
    }
    
}
