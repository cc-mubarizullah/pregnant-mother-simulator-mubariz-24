using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective09 : MonoBehaviour
{
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] ObjectivesSO ninthObjective;
    [SerializeField] Objective9Trigger objective9Trigger;
    [SerializeField] GameObject reportInHand;
    [SerializeField] GameObject reportOnTable;

    public UnityEvent eventToHappenOnEnable;
    public UnityEvent eventToHappenOnDisEnable;

    public static event EventHandler OnObj09Update;
    public static event EventHandler OnObj09Complete;

    float clock;
    float clock2;
    bool hasInteractedWithDoctor;

    private void OnEnable()
    {
        eventToHappenOnEnable.Invoke();

    }

    private void Start()
    {
        objective9Trigger.OnPlayerTriggDocTable += Objective9Trigger_OnPlayerTriggDocTable;
    }

    private void Objective9Trigger_OnPlayerTriggDocTable()
    {
        hasInteractedWithDoctor = true;
        reportInHand.SetActive(false);
        reportOnTable.SetActive(true);
    }

    private void Update()
    {
        DelayObjUIAfterActivation();
        CheckProgress();
        objectiveShowUI.ShowObjectiveText(ninthObjective.objectivesText);
    }

    bool DelayObjAfterComplete()
    {
        clock2 += Time.deltaTime;
        if (clock2 >= 0.4f)
        {
            return true;
        }
        return false;
    }
    void DelayObjUIAfterActivation()   // this function will be called by update and corresponding objective will be shown after 4 sec
    {
        clock += Time.deltaTime;
        if (clock > 2f && clock < 2.1f)
        {
            OnObj09Update?.Invoke(this, EventArgs.Empty);
        }
    }

    void CheckProgress()
    {
        if (hasInteractedWithDoctor)
        {
            if (DelayObjAfterComplete())
            {
                //LEVEL 2 COMPLETES HERE
                OnObj09Complete?.Invoke(this, EventArgs.Empty);
                Destroy(gameObject);
            }
        }
    }

    private void OnDisable()
    {
        eventToHappenOnDisEnable?.Invoke();
    }
}


