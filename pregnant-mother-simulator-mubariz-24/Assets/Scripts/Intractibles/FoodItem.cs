using System;
using UnityEngine;
using UnityEngine.EventSystems;

// this script should be attached with food items that will increase or decrease BABY'S HEALTH BAR.
public class FoodItem : MonoBehaviour, IInteractWithIneractables, IInventoryHandler
{
    public event EventHandler OnEatingHealthy;

    enum FoodType
    {
        Healthy,
        Unhealthy
    }

    [Tooltip("Choose type of food.")]
    [SerializeField] FoodType foodType;

    [Tooltip("Name of the item will not be shown if this component is not setup correctly.")]
    [SerializeField] IntractiblesSO intractiblesSO;     

    
    public void Interact()
    {
        ShowItemText();
    }

    void ShowItemText()
    {
        InteractiveItemTextUI.Instance.SetItemTextFromSO(intractiblesSO);
    }    

    public void PhysicalInteract()
    {
        switch (foodType)
        {
            case FoodType.Healthy:
                if (BabyHealthBarUI.Instance.currentBabyHealth < 94)
                {
                    OnEatingHealthy?.Invoke(this, EventArgs.Empty);
                    BabyHealthBarUI.Instance.UpdateBabyHealthUI(GameManager.Instance.healthGainedbyRightAction);
                }

                break;

            case FoodType.Unhealthy:

                if (BabyHealthBarUI.Instance.currentBabyHealth > 0)
                {
                    BabyHealthBarUI.Instance.UpdateBabyHealthUI(GameManager.Instance.healthLooseByWrongAction);
                }
                
                break;
            
        }

        Destroy(gameObject);
    }

    public void Grab()
    {
        Debug.Log("The object is grabbed.");
    }
}
