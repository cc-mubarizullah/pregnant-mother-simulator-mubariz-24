using UnityEngine;

public class ObjectDrop : MonoBehaviour, IInteractWithIneractables
{
    [SerializeField] GameObject[] objectsToAppear;
    [SerializeField] InteractiveItemTextUI interactiveItemTextUI;

    public void Interact()
    {
        interactiveItemTextUI.SetItemText("Place here");
    }

    public void PhysicalInteract()
    {
        foreach (GameObject item in objectsToAppear)
        {
            item.SetActive(true);
        }
    }
}
