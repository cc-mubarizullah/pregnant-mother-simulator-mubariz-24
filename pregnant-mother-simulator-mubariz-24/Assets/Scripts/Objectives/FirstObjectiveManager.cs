using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FirstObjectiveManager : MonoBehaviour
{
    bool hasEatenHealthty;

    [SerializeField] ObjectivesSO firstObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] HintUI hintUI;

    [SerializeField] string textOnEatingUnhealthyFood;
    FoodItem[] foodItem;
    public int healthyFruitsEaten;
    public int totalHealthyFruitsToEat = 4;

    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    public static event EventHandler OnL01Obj01Update;
    public static event EventHandler OnL01Obj01Complete; // declaring an event for objective 1 complete

    float clock;
    private void Start()
    {
        
        foodItem = FindObjectsByType<FoodItem>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach(FoodItem item in foodItem)
        {
            item.OnEatingHealthy += Item_OnEatingHealthy;
            item.OnEatingUnhealthy += Item_OnEatingUnhealthy;
        }

        objectiveShowUI.gameObject.SetActive(true);
 
    }

    

    private void Update()
    {
        CheckingAllFoodItems();
        DelayAfterActivation();
        objectiveShowUI.ShowObjectiveText(firstObjectiveSO.objectivesText);
        CheckProgress();
    }

    private void Item_OnEatingHealthy(object sender, System.EventArgs e)
    {
        if(healthyFruitsEaten < 4)
        {
            healthyFruitsEaten++;
        }
    }

    private void Item_OnEatingUnhealthy(object sender, System.EventArgs e)
    {
        if (!hasEatenHealthty)
        {
            hintUI.gameObject.SetActive(true);
            hintUI.ShowHintText(textOnEatingUnhealthyFood);
            hasEatenHealthty = true;
        }
    }

    // Logic for ObjectiveComplete
    private void CheckProgress()
    {
        if(healthyFruitsEaten == totalHealthyFruitsToEat)
        {
            //OBJECTIVE COMPLETE
            firstObjectiveSO.isObjectiveComplete = true;
            // raising event when obj 1 complete
            OnL01Obj01Complete?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject, 1f);
        }
    }

    private void OnEnable()
    {
        eventsToCallWhenEnable?.Invoke();
    }
    private void OnDisable()
    {
        eventsToCallWhenDisable?.Invoke();
        foreach (FoodItem item in foodItem)
        {
            item.gameObject.layer = 0;
        }
        
    }
    void DelayAfterActivation()     // this function will fire event that objective ui will listen and show objective animation
    {
        clock += Time.deltaTime;
        if (clock > 4f && clock < 4.5f)
        {
            OnL01Obj01Update?.Invoke(this, EventArgs.Empty);
        }
    }

    void CheckingAllFoodItems()
    {
        foodItem = FindObjectsByType<FoodItem>(FindObjectsInactive.Include, FindObjectsSortMode.None);
    }

}
