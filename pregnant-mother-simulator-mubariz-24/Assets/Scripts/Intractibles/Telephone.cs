using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Telephone : MonoBehaviour, IInteractWithIneractables
{
    bool canInteract = true;
    Animator m_Animator;
    const string IS_PICKUP = "isPickup";
    const string IS_TALKING = "isTalking";
    public event EventHandler OnCallEnds;
    float timer;
    float audioClipLenght = 38f;
    AudioSource m_AudioSource;
    MusicManager musicManaer;
    bool startTimer = false;
    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();
        Debug.Log(m_AudioSource.clip.name);
        musicManaer = FindAnyObjectByType<MusicManager>();
    }
    public void Interact()
    {
        if (canInteract)
        {
            InteractiveItemTextUI.Instance.SetItemText("Call Doctor!");
        }
    }



    public void PhysicalInteract()
    {
        if (canInteract)
        {
            m_Animator.SetBool(IS_PICKUP, true);
            canInteract = false;
        }
    }

    private void Update()
    {
        if (!canInteract)
            gameObject.layer = 0;    //set layer to default

        if(startTimer)
        {
            StartTalking();
        }
    }

    public void StartTalkingAnimation()   // this function will serve as a animation event in animation of telephone to start talking animation
    {
        m_Animator.SetBool(IS_PICKUP, false);
        m_Animator.SetBool(IS_TALKING, true);
        startTimer = true;
        musicManaer.PauseSound();
        m_AudioSource.Play();
    }

    private void StartTalking()
    {
        timer += Time.deltaTime;
        if (timer >= audioClipLenght)
        {
            //PLAYER ENDS TALKING
            m_Animator.SetBool(IS_TALKING, false);
            OnCallEnds?.Invoke(this, EventArgs.Empty);
            musicManaer.PlaySound();
            startTimer = false;
        }
    }
}
