using System;
using UnityEngine;

public class DropArea : MonoBehaviour, IInteractWithIneractables
{
    public Action OnBabyItemDropped;

    InteractiveItemTextUI itemTextUI;
    [SerializeField] GameObject particleSystemGOofArea;
    [SerializeField] GameObject visualToSetActive;
    [SerializeField] GameObject itemOnPlayerHand;
    private void Start()
    {
        itemTextUI = FindFirstObjectByType<InteractiveItemTextUI>();
    }
    public void Interact()
    {
        itemTextUI.SetItemText("Drop");
    }

    public void PhysicalInteract()
    {
        particleSystemGOofArea.SetActive(false);
        visualToSetActive.SetActive(true);
        itemOnPlayerHand.SetActive(false);
        OnBabyItemDropped?.Invoke();
        gameObject.layer = 0;
        OnBabyItemDropped?.Invoke();
    }
}
