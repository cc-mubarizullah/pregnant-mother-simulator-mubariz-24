using UnityEngine;

public interface IInteractWithIneractables
{
    // every class thats inhereting from this interface would have to implement these functions
    public void Interact();
    public void PhysicalInteract();
}
