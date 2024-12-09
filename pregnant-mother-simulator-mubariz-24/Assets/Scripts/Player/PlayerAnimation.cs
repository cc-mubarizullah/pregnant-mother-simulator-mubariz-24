using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Player player;

    [SerializeField] Animator animator;

    private void Player_OnPhysicalInteraction()
    {
        animator.SetBool("interact", true);
        Debug.Log("working");
    }

    public void ResetInteract()
    {
        animator.SetBool("interact", false);
    }

    private void OnEnable()
    {
        player.OnPhysicalInteraction += Player_OnPhysicalInteraction;
    }
    private void OnDisable()
    {
        player.OnPhysicalInteraction -= Player_OnPhysicalInteraction;       
    }


}
