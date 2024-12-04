using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective28 : MonoBehaviour
{
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] ObjectivesSO twentyEightObjective;
    [SerializeField] GameObject sleepingTransitionImageGO;

    public UnityEvent eventToHappenOnEnable;
    public UnityEvent eventToHappenOnDisEnable;

    public static event EventHandler OnObj28Update;
    public static event EventHandler OnObj28Complete;

    float clock;
    float clock2;
    bool hasTriggerBed;

    private void OnEnable()
    {
        eventToHappenOnEnable.Invoke();

    }

    private void Start()
    {
        BedTrigger bedTrigger = FindAnyObjectByType<BedTrigger>();
        bedTrigger.OnPlayerTriggerBed += BedTrigger_OnPlayerTriggerBed;
    }

    private void BedTrigger_OnPlayerTriggerBed()
    {
        hasTriggerBed = true;
        sleepingTransitionImageGO.SetActive(true);
    }

    private void Update()
    {
        DelayObjUIAfterActivation();
        CheckProgress();
        objectiveShowUI.ShowObjectiveText(twentyEightObjective.objectivesText);
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
        if (clock > 2f && clock < 2.1f)
        {
            OnObj28Update?.Invoke(this, EventArgs.Empty);
        }
    }

    void CheckProgress()
    {
        if (hasTriggerBed)
        {
            if (DelayObjAfterComplete())
            {
                //LEVEL 2 COMPLETES HERE
                OnObj28Complete?.Invoke(this, EventArgs.Empty);
                Destroy(gameObject, 2f);
            }
        }
    }

    private void OnDisable()
    {
        eventToHappenOnDisEnable?.Invoke();
    }
}
