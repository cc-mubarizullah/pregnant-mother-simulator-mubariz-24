using System;
using UnityEngine;

public class ToysToGather : MonoBehaviour, IInteractWithIneractables
{
    public event Action OnToyGather;

    [SerializeField] InteractiveItemTextUI interactiveItemTextUI;
    public void Interact()
    {
        interactiveItemTextUI.SetItemText("Collect");
    }

    public void PhysicalInteract()
    {
        Destroy(gameObject);
        OnToyGather?.Invoke();
    }
}
