using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class FirstObjectiveManager : MonoBehaviour
{
    bool hasEatenUnhealthy = false;

    [SerializeField] ObjectivesSO firstObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] HintUI hintUI;
    [SerializeField] string textOnEatingUnhealthyFood;
    FoodItem[] foodItem;
    public int healthyFruitsEaten;
    public int totalHealthyFruitsToEat = 4;

    public UnityEvent eventToSubscribeOnEnable;
    public UnityEvent eventToSubscribeOnDisable;

    private void Start()
    {
        foodItem = FindObjectsByType<FoodItem>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach(FoodItem item in foodItem)
        {
            item.OnEatingHealthy += Item_OnEatingHealthy;
            item.OnEatingUnhealthy += Item_OnEatingUnhealthy;
        }
 
    }

    

    private void Update()
    {
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
        hintUI.gameObject.SetActive(true);
        hintUI.ShowHintText(textOnEatingUnhealthyFood);
        hasEatenUnhealthy = true;
    }

    private void CheckProgress()
    {
        if(healthyFruitsEaten == totalHealthyFruitsToEat)
        {
            Debug.Log("first objective is complete");
            objectiveShowUI.ShowObjectiveText(firstObjectiveSO.objectivesText);
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        eventToSubscribeOnEnable?.Invoke();
    }
    private void OnDisable()
    {
        eventToSubscribeOnDisable?.Invoke();
    }
    
}
