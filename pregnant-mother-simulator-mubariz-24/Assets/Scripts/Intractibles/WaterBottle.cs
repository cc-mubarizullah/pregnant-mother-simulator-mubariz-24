using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WaterBottle : MonoBehaviour
{
    const string IS_POUR = "isPour";
    bool canPour;

    private void Start()
    {
        canPour = true; ;
        Animator animator = GetComponent<Animator>();
        animator.SetBool(IS_POUR, canPour);
    }

    public void ReversingBool()
    {
        if(canPour)
            canPour=false;
    }
}
