using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField] Animator animator;
    private void Start()
    {
        Player player = GetComponent<Player>();
        player.OnPhysicalInteraction += Player_OnPhysicalInteraction;

    }

    private void Player_OnPhysicalInteraction()
    {
        animator.SetBool("interact", true);
    }

    public void ResetInteract()
    {
        animator.SetBool("interact", false);
    }

   
}
