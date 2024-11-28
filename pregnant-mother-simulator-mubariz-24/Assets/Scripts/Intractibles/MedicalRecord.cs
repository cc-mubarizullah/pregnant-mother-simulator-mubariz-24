using System;
using UnityEngine;

public class MedicalRecord : MonoBehaviour, IInteractWithIneractables
{
    bool canAnimate;
    float elapsedTime;
    float timeForAnimation = 0.5f;
    public Action OnGrabReport;
    Vector3 restPositionOfItem;
    private void Start()
    {
        restPositionOfItem = transform.position;
    }
    private void Update()
    {
        if (canAnimate)
        {
            GrabAnimation();
        }
    }
    public void Interact()
    {
        InteractiveItemTextUI.Instance.SetItemText("Grab Rrecord");
    }

    public void PhysicalInteract()
    {
        canAnimate = true;
        OnGrabReport?.Invoke();
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
