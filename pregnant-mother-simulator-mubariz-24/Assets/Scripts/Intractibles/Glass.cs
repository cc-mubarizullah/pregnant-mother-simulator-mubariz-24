using System;
using UnityEngine;

public class Glass : MonoBehaviour, IInteractWithIneractables
{
    Vector3 restPosition;
    [SerializeField] Transform grabPositionOfPlayer;
    float timeToAnimate = 1f;
    float elapsedTime;
    bool canDrinkWater = false;
    bool canStartDrinkAnimation;
    bool canPlaceBack;
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
            canDrinkWater = false;
            //gameObject.layer = 0;  //resetting layer to default
            canStartDrinkAnimation = true;
        }
    }

    private void Update()
    {
        if (canStartDrinkAnimation)
        {
            DrinkAnimation();
        }
        if (canPlaceBack)
        {
            PlaceGalssBack();
        }
    }


    // Below function will be called when Water is Poured inside glass
    private void WaterBottle_OnPourWater(object sender, System.EventArgs e)
    {
        canDrinkWater = true;
        gameObject.layer = 7;   // set the layer of glass to 7 to make it interactive after it has been filled with water
        canPlaceBack = false;
    }

    public void DrinkAnimation()
    {
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / timeToAnimate;
        transform.position = Vector3.Lerp(restPosition, PlayerGrabPoint(), t);
        if (Vector3.Distance(transform.position, PlayerGrabPoint()) < 0.01f)
        {
            SFXmanager.Instance.PlaySoundEffectOnPosition(SFXmanager.Instance.waterDrinkSFX, transform.position);
            elapsedTime = 0;
            waterInsideGlass.SetActive(false);
            canStartDrinkAnimation = false;
            canPlaceBack = true;
        }
    }
    private void PlaceGalssBack()
    {
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / timeToAnimate;
        transform.position = Vector3.Lerp(PlayerGrabPoint(), restPosition, t);
        if (Vector3.Distance( transform.position, PlayerGrabPoint() ) < 0.01f)
        {
            elapsedTime = 0;
            canPlaceBack = false;
            
        }
    }

    Vector3 PlayerGrabPoint()
    {
        return Player.Instance.GetGrabPosition();
    }



}
