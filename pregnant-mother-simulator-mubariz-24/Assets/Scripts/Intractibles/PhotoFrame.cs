using UnityEngine;

public class PhotoFrame : MonoBehaviour, IInteractWithIneractables
{
    [SerializeField] GameObject photoFrameInPlayer;
    [SerializeField] InteractiveItemTextUI interactiveItemText;
    public void Interact()
    {
        interactiveItemText.SetItemText("Baby Photo");
    }

    public void PhysicalInteract()
    {
        photoFrameInPlayer.SetActive(true);
        Destroy(gameObject);
    }
}
