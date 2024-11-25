using System;
using UnityEngine;

public class Glass : MonoBehaviour, IInteractWithIneractables
{
    bool canDrinkWater = false;
    WaterBottle waterBottle;
    [SerializeField] GameObject waterInsideGlass;
    public event EventHandler OnWaterDrunk;
    private void Start()
    {
        waterBottle = FindAnyObjectByType<WaterBottle>();
        waterBottle.OnPourWater += WaterBottle_OnPourWater;
    }
    public void Interact()
    {
        if (canDrinkWater)
        {
            InteractiveItemTextUI.Instance.SetItemText("Drink Water");
        }
    }

    public void PhysicalInteract()
    {
        if (canDrinkWater)
        {
            waterInsideGlass.SetActive(false);
            //WATER IS DRUNK
            OnWaterDrunk?.Invoke(this, EventArgs.Empty);
            canDrinkWater = false;
        }
    }


    // Below function will be called when Water is Poured inside glass
    private void WaterBottle_OnPourWater(object sender, System.EventArgs e)
    {
        canDrinkWater = true;
        gameObject.layer = 7;   // set the layer of glass to 7 to make it interactive after it has been filled with water
    }


    

}
