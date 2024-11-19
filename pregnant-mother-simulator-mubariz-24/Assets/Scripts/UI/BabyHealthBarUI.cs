using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

// Script should be attached with UI gameobject that has image gameobject as a children
public class BabyHealthBarUI : MonoBehaviour
{
    public static BabyHealthBarUI Instance {  get; set; }   


    [SerializeField] Image babyHealthBarImage;

    [SerializeField] int totalBabyHealth = 100;

    public int currentBabyHealth;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        babyHealthBarImage.fillAmount = (float)currentBabyHealth / totalBabyHealth;
    }

    public void UpdateBabyHealthUI(int healthIncrementValue)
    {
        if (currentBabyHealth <= 95)
        {
            currentBabyHealth += healthIncrementValue;
            currentBabyHealth = Mathf.Clamp(currentBabyHealth, 0, 100);
        }
    }


}
