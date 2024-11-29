using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective11 : MonoBehaviour
{
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] ObjectivesSO eleventhObjective;
    [SerializeField] HintUI hintUI;
    [SerializeField] Objective11TriggerweightMachine objective11TriggerweightMachine;

    public UnityEvent eventToHappenOnEnable;
    public UnityEvent eventToHappenOnDisEnable;

    public static event EventHandler OnObj11Update;
    public static event EventHandler OnObj11Complete;

    float clock;
    float clock2;
    bool hasInteractedWithWMachine;
    bool hasStayedEnough;
    bool hasInteractedBefore = false;

    private void OnEnable()
    {
        eventToHappenOnEnable.Invoke();

    }

    private void Start()
    {
        objective11TriggerweightMachine.OnPlayerTriggWeightmachine += Objective11TriggerweightMachine_OnPlayerTriggWeightmachine;
        objective11TriggerweightMachine.OnPlayerStayedEnoughInTriggerArea += Objective11TriggerweightMachine_OnPlayerStayedEnoughInTriggerArea;
    }

    private void Objective11TriggerweightMachine_OnPlayerStayedEnoughInTriggerArea()
    {
        hasStayedEnough = true;
    }

    private void Objective11TriggerweightMachine_OnPlayerTriggWeightmachine()
    {
        if (!hasInteractedBefore)
        {
            hasInteractedWithWMachine = true;
            hintUI.gameObject.SetActive(true);
            hintUI.ShowHintText("Stay calm. Do not move");
            hasInteractedBefore = true;
        }
    }

    private void Update()
    {
        DelayObjUIAfterActivation();
        CheckProgress();
        objectiveShowUI.ShowObjectiveText(eleventhObjective.objectivesText);
    }

    bool DelayObjAfterComplete()
    {
        clock2 += Time.deltaTime;
        if (clock2 >= 2f)
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
            OnObj11Update?.Invoke(this, EventArgs.Empty);
        }
    }

    void CheckProgress()
    {
        if (hasInteractedWithWMachine && hasStayedEnough)
        {
            if (DelayObjAfterComplete())
            {
                //LEVEL 2 COMPLETES HERE
                OnObj11Complete?.Invoke(this, EventArgs.Empty);
                hintUI.gameObject.SetActive(true);
                hintUI.ShowHintText("Your weight is =  67");
                Debug.Log("Objective 11 Complete");
                Destroy(gameObject);

            }
        }
    }

    private void OnDisable()
    {
        eventToHappenOnDisEnable?.Invoke();
    }
}
