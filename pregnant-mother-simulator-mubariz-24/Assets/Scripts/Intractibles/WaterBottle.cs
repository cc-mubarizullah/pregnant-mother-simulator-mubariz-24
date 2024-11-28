using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WaterBottle : MonoBehaviour, IInteractWithIneractables
{
    [SerializeField] GameObject waterInsideGlass;
    [SerializeField] IntractiblesSO waterSO;
    const string IS_POUR = "isPour";
    Animator animator;
    public event EventHandler OnPourWater;
    private void Start()
    {
        animator = GetComponent<Animator>();   
    }

    public void ReversingBool()      //this function is used in animation
    {
        animator.SetBool(IS_POUR, false);
    }

    public void PlayPouringSFX()     //  this function is used in animation 
    {
        SFXmanager.Instance.PlaySoundEffectOnPosition(SFXmanager.Instance.waterPouringSFX, Camera.main.transform.position);
    }

    public void Interact()
    {
        InteractiveItemTextUI.Instance.SetItemText("Pour Water!");
    }

    public void PhysicalInteract()
    {
        animator.SetBool(IS_POUR, true);
    }

    public void FirePourEvent()          //function used in animation
    {
        OnPourWater?.Invoke(this, EventArgs.Empty);
    }
    public void FillGlass()              // function used in animation
    {
        waterInsideGlass.SetActive(true);
    }
}
