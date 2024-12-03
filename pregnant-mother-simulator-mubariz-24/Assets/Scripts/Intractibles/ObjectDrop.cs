using UnityEngine;
using System;

public class ObjectDrop : MonoBehaviour, IInteractWithIneractables
{
    public event Action OnPhotoHanged;

    [SerializeField] GameObject[] objectsToAppear;
    [SerializeField] InteractiveItemTextUI interactiveItemTextUI;
    [SerializeField] GameObject particleSystemGO;
    [SerializeField] GameObject photoInPlayerHand;
    [SerializeField] GameObject whiteBabyFrame;

    public void Interact()
    {
        interactiveItemTextUI.SetItemText("Place here");
    }

    public void PhysicalInteract()
    {
        OnPhotoHanged?.Invoke();
        foreach (GameObject item in objectsToAppear)
        {
            whiteBabyFrame.layer = 7;
            item.SetActive(true);
            particleSystemGO.SetActive(false);
            Destroy(photoInPlayerHand);
        }
    }
}
