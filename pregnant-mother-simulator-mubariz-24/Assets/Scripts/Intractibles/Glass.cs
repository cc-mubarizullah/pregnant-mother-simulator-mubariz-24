using System;
using UnityEngine;

public class Glass : MonoBehaviour, IInteractWithIneractables
{
    Vector3 restPosition;
    [SerializeField] Transform grabPositionOfPlayer;  
    bool canDrinkWater = false;
    WaterBottle waterBottle;
    [SerializeField] GameObject waterInsideGlass;
    public event EventHandler OnWaterDrunk;
    private void Start()
    {
        restPosition = transform.position;
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
            //WATER IS DRUNK
            OnWaterDrunk?.Invoke(this, EventArgs.Empty);
            waterInsideGlass.SetActive(false);
            canDrinkWater = false;
            //gameObject.layer = 0;  //resetting layer to default
        }
    }

    // Below function will be called when Water is Poured inside glass
    private void WaterBottle_OnPourWater(object sender, System.EventArgs e)
    {
        canDrinkWater = true;
        gameObject.layer = 7;   // set the layer of glass to 7 to make it interactive after it has been filled with water
    }
}
