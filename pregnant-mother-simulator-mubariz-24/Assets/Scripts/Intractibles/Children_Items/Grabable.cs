using System;
using UnityEngine;

public class Grabable : MonoBehaviour, IInteractWithIneractables
{
    [SerializeField] GameObject AreaToSetInteractive;
    [SerializeField] GameObject particleSysGOofArea;
    [SerializeField] GameObject itemOnPlayerToSetActive;
    InteractiveItemTextUI itemTextUI;


    private void Start()
    {
        itemTextUI = FindFirstObjectByType<InteractiveItemTextUI>();
    }
    public void Interact()
    {
        itemTextUI.SetItemText("Grab");
    }

    public void PhysicalInteract()
    {
        gameObject.SetActive(false);
        AreaToSetInteractive.layer = 7;
        particleSysGOofArea.SetActive(true);
        itemOnPlayerToSetActive.SetActive(true);    
    }
}
