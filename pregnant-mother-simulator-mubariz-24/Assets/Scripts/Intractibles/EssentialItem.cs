using System;
using UnityEngine;

public class EssentialItem : MonoBehaviour, IInteractWithIneractables
{
    float elapsedTime;
    float timeForAnimation = 0.5f;
    Vector3 restPositionOfItem;
    bool canAnimate;
    private void Start()
    {
        restPositionOfItem = transform.position;
    }
    public Action OnGrabEssentials;
    public void Interact()
    {
        InteractiveItemTextUI.Instance.SetItemText("Grab");
    }

    public void PhysicalInteract()
    {
        canAnimate = true;
        OnGrabEssentials?.Invoke();
    }

    private void Update()
    {
        if (canAnimate)
        {
            GrabAnimation();
        }
    }

    void GrabAnimation()
    {
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / timeForAnimation;
        transform.position = Vector3.Lerp(restPositionOfItem, PlayerGrabPoint(), t);

        if (transform.position == PlayerGrabPoint())
        {
            elapsedTime = 0;
            Destroy(gameObject);
        }
    }

    Vector3 PlayerGrabPoint()
    {
        return Player.Instance.GetGrabPosition();
    }
}
