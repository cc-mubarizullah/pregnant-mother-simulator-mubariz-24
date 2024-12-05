using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;        // this class works with list (this time we used one bool property (IsAny())  and function (First()) )

public class Objective06 : MonoBehaviour
{
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] ObjectivesSO sixthObjectiveSO;
     QuestPointer questPointer;
    [SerializeField] GameObject questImage;

    public UnityEvent eventsToHappenOnEnable;
    public UnityEvent eventsToHappenOnDisable;

    public static event EventHandler OnObj06Update;
    public static event EventHandler OnObj06Complete;

    List<EssentialItem> essentialItemsList;           // declared a list to hold all the essentials

    float clock;
    float clock2;
    int essentialsCount;
   
    bool hasEssentialsGathered;
    EssentialItem[] allEssentialItems;      // declared an array to store all the gameobject with same class

    private void OnEnable()
    {
        eventsToHappenOnEnable?.Invoke();
    }

    private void Awake()
    {
        questImage.SetActive(true);
        questPointer = questImage.GetComponent<QuestPointer>();
        essentialItemsList = new List<EssentialItem>();
    }

    private void Start()
    {
        allEssentialItems = FindObjectsByType<EssentialItem>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (EssentialItem item in allEssentialItems)
        {
            item.OnGrabEssentials = () => EssentialItem_OnGrabEssential(item);
            essentialItemsList.Add(item);
        }

        if (questPointer == null)
        {
            Debug.LogError("questPointer not found");
        }

        if (essentialItemsList.Any()) // if there is any element in the list 
        {
            essentialItemsList.First().transform.gameObject.layer = 7;          // then grab the first element and set its layer to interactive
            questPointer.SetQuestTransform(essentialItemsList.First().transform);   // send its transform to QuestPointer Class for navigation
        }

    }

    private void Update()
    {
        DelayObjUIAfterActivation();
        CheckProgress();
        objectiveShowUI.ShowObjectiveText(sixthObjectiveSO.objectivesText);
    }

    void DelayObjUIAfterActivation()   // this function will be called by update and corresponding objective will be shown after 4 sec
    {
        clock += Time.deltaTime;
        if (clock > 1f && clock < 1.1f)
        {
            OnObj06Update?.Invoke(this, EventArgs.Empty);
        }
    }

    void CheckProgress()
    {
        if (hasEssentialsGathered)
        {
            if (DelayAfterObjectiveComplete())
            {
                //OBJECTIVE COMPLETES HERE
                OnObj06Complete?.Invoke(this, EventArgs.Empty);
                questImage.SetActive(false);
                Destroy(gameObject , 0.1f);
            }
        }
    }

    bool DelayAfterObjectiveComplete()
    {
        clock2 += Time.deltaTime;
        if (clock2 > 1f)
        {
            return true;
        }
        return false;
    }

    void EssentialItem_OnGrabEssential(EssentialItem item)
    {
        int totalEssentialsToGrab = allEssentialItems.Length;
        essentialsCount++;
        essentialItemsList.Remove(item);

        if (essentialItemsList.Any())      // if there is any element in the list 
        {
            essentialItemsList.First().transform.gameObject.layer = 7;  // take the first one and set its layer to interactive
            questPointer.SetQuestTransform(essentialItemsList.First().transform);  // send that gameobject transform to QuestPointer class for navigation
        }

        if (essentialsCount == totalEssentialsToGrab)
        {
            hasEssentialsGathered = true;
        }
    }
   

    private void OnDisable()
    {
        eventsToHappenOnDisable?.Invoke();
        
    }


}
