using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective10 : MonoBehaviour
{
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] ObjectivesSO tenthObjective;
    [SerializeField] Objective10_Trigger objective10_Trigger;
    [SerializeField] HintUI hintUI;

    public UnityEvent eventToHappenOnEnable;
    public UnityEvent eventToHappenOnDisEnable;

    public static event EventHandler OnObj10Update;
    public static event EventHandler OnObj10Complete;

    float clock;
    float clock2;
    bool hasInteractedBefore = false;
    bool hasInteractedWithBPmach;
    bool hasPlayerStayedEnogh;

    private void OnEnable()
    {
        eventToHappenOnEnable.Invoke();

    }

    private void Start()
    {
        objective10_Trigger.OnPlayerTriggBPmachine += Objective10_Trigger_OnPlayerTriggBPmachine;
        objective10_Trigger.OnPlayerStayedEnoughInTriggerArea += Objective10_Trigger_OnPlayerStayedEnoughInTriggerArea;
    }

    private void Objective10_Trigger_OnPlayerStayedEnoughInTriggerArea()
    {
        hasPlayerStayedEnogh = true;
    }

    private void Objective10_Trigger_OnPlayerTriggBPmachine()
    {
        if (!hasInteractedBefore)
        {
            hasInteractedWithBPmach = true;
            hintUI.gameObject.SetActive(true);
            hintUI.ShowHintText("Stay calm. Do not move");
            hasInteractedBefore = true; 
        }

    }

    private void Update()
    {
        DelayObjUIAfterActivation();
        CheckProgress();
        objectiveShowUI.ShowObjectiveText(tenthObjective.objectivesText);
    }

    bool DelayObjAfterComplete()
    {
        clock2 += Time.deltaTime;
        if (clock2 >= 1f)
        {
            return true;
        }
        return false;
    }
    void DelayObjUIAfterActivation()   // this function will be called by update and corresponding objective will be shown after 4 sec
    {
        clock += Time.deltaTime;
        if (clock > 2.5f && clock < 2.6f)
        {
            OnObj10Update?.Invoke(this, EventArgs.Empty);
        }
    }

    void CheckProgress()
    {
        if (hasInteractedWithBPmach && hasPlayerStayedEnogh)
        {
            if (DelayObjAfterComplete())
            {
                //LEVEL 2 COMPLETES HERE
                OnObj10Complete?.Invoke(this, EventArgs.Empty);
                hintUI.gameObject.SetActive(true);
                hintUI.ShowHintText("Blood Pressure =  83 / 125.");
                Debug.Log("Objective 10 Complete");
                Destroy(gameObject);

            }
        }
    }

    private void OnDisable()
    {
        eventToHappenOnDisEnable?.Invoke();
    }
}
