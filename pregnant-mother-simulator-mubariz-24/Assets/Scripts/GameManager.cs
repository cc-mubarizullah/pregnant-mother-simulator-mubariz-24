using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
    Instance = this;    
    }
    [Tooltip("The amount of Baby's health increase by eating healthy food.")]
    public int healthGainedbyRightAction = 2;
    [Tooltip("The amount of Baby's health decrease by eating healthy food.")]
    public int healthLooseByWrongAction = -2;
    [Tooltip("The amount of Baby's health decrease when not eating something.")]
    public int healthDecNotEating = 5;
}
