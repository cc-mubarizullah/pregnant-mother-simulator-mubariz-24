using System;
using UnityEngine;

public class PhotoFrame : MonoBehaviour, IInteractWithIneractables
{
    

    [SerializeField] GameObject photoFrameInPlayer;
    [SerializeField] InteractiveItemTextUI interactiveItemText;
    [SerializeField] GameObject particleSystemGO;
    [SerializeField] GameObject dropPlaceObject;
    [SerializeField] GameObject whiteBabyFrame;


    public void Interact()
    {
        interactiveItemText.SetItemText("Baby Photo");
    }

    public void PhysicalInteract()
    {
        dropPlaceObject.layer = 7;
        photoFrameInPlayer.SetActive(true);
        particleSystemGO.SetActive(true);
        gameObject.SetActive(false); 
    }
}
