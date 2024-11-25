using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WaterBottle : MonoBehaviour, IInteractWithIneractables
{
    [SerializeField] GameObject waterInsideGlass;
    [SerializeField] IntractiblesSO waterSO;
    const string IS_POUR = "isPour";
    Animator animator;
    bool canPour;
    float clock;
    public event EventHandler OnPourWater;
    private void Start()
    {
        animator = GetComponent<Animator>();   
    }

    public void ReversingBool()
    {
        animator.SetBool(IS_POUR, false);
    }

    public void PlayPouringSFX()
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

    public void FirePourEvent()
    {
        OnPourWater?.Invoke(this, EventArgs.Empty);
    }
    public void FillGlass()
    {
        waterInsideGlass.SetActive(true);
    }
}
