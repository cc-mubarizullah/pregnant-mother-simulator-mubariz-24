using System;
using UnityEngine;

public class ToyBox : MonoBehaviour, IInteractWithIneractables
{
    public event Action OnPutInBox;

    [SerializeField] InteractiveItemTextUI interactiveItemTextUI;
    [SerializeField] GameObject toysInsideBox;
    public void Interact()
    {
        interactiveItemTextUI.SetItemText("Put toys inside"); 
    }

    public void PhysicalInteract()
    {
        OnPutInBox?.Invoke();
        toysInsideBox.SetActive(true);  
    }


   
}
