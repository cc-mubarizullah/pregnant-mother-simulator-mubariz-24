using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HintUIAnimation : MonoBehaviour
{
    Animator animator;
    const string ANIMATE = "Animate";
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    bool canAnimate;
    private void OnEnable()
    {
        canAnimate = true;
    }
    private void Update()
    {
        if (canAnimate)
            animator.SetTrigger(ANIMATE);
    }

    // this function will be used as an animation event and will serve for the purpose of deactivation of this gameobject at the end of animation
    public void Deactivation()
    {
        canAnimate = false;
        gameObject.SetActive(false);
    }

    public void PlayHintSound()
    {
        SFXmanager.Instance.PlaySoundEffectOnPosition(SFXmanager.Instance.hintSFX, Player.Instance.transform.position);
    }
}
