using System;
using UnityEngine;
using UnityEngine.Events;

public class Objecitive26 : MonoBehaviour
{
    bool hasEatenHealthty;

    [SerializeField] ObjectivesSO twentySixObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] HintUI hintUI;

    [SerializeField] string textOnEatingUnhealthyFood;
    FoodItem[] foodItemAtStart;
    FoodItem[] foodItemLeft;
    int healthyFruitsEaten;
    int totalHealthyFruitsToEat = 6;

    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    public static event EventHandler OnObj26Update;
    public static event EventHandler OnObj26Complete; // declaring an event for objective 1 complete

    float clock;
    float clock2;
    bool hasEatenAllFood;

    private void OnEnable()
    {
        eventsToCallWhenEnable?.Invoke();
    }
    private void Start()
    {

        foodItemAtStart = FindObjectsByType<FoodItem>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (FoodItem item in foodItemAtStart)
        {
            item.gameObject.layer = 7;
            item.OnEatingHealthy += Item_OnEatingHealthy;
            item.OnEatingUnhealthy += Item_OnEatingUnhealthy;
        }

        objectiveShowUI.gameObject.SetActive(true);

    }



    private void Update()
    {
        CheckingAllFoodItems();
        DelayAfterActivation();
        objectiveShowUI.ShowObjectiveText(twentySixObjectiveSO.objectivesText);
        CheckProgress();
    }
    void CheckingAllFoodItems()
    {
        foodItemLeft = FindObjectsByType<FoodItem>(FindObjectsInactive.Include, FindObjectsSortMode.None);
    }
    private void CheckProgress()
    {
        if (hasEatenAllFood)
        {
            if (DelayAfterObjComplete())
            {
                //OBJECTIVE COMPLETE
                twentySixObjectiveSO.isObjectiveComplete = true;
                // raising event when obj 1 complete
                OnObj26Complete?.Invoke(this, EventArgs.Empty);
                Destroy(gameObject, 0.1f);

            }
        }
    }

    bool DelayAfterObjComplete()
    {
        clock2 += Time.deltaTime;
        if (clock2 >= 1f)
        {
            return true;
        }
        return false;
    }

    void DelayAfterActivation()     // this function will fire event that objective ui will listen and show objective animation
    {
        clock += Time.deltaTime;
        if (clock > 1f && clock < 1.1f)
        {
            OnObj26Update?.Invoke(this, EventArgs.Empty);
        }
    }

    private void Item_OnEatingHealthy(object sender, System.EventArgs e)
    {
        if (healthyFruitsEaten < totalHealthyFruitsToEat)
        {
            healthyFruitsEaten++;
        }
        if (healthyFruitsEaten == totalHealthyFruitsToEat)
        {

            hasEatenAllFood = true;
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
    private void OnDisable()
    {
        eventsToCallWhenDisable?.Invoke();
        foreach (FoodItem item in foodItemLeft)
        {
            if (item != null)
            {
                item.gameObject.layer = 0;
            }
        }
    }

}
