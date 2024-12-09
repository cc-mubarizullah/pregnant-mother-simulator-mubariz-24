using UnityEngine;
using System;
using UnityEngine.Events;

public class Objective08 : MonoBehaviour
{
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] ObjectivesSO eightObjective;
    [SerializeField] GameObject sleepingTransitionImageGO;


    public UnityEvent eventToHappenOnEnable;
    public UnityEvent eventToHappenOnDisEnable;

    public static event EventHandler OnObj08Update;
    public static event EventHandler OnObj08Complete;

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
        objectiveShowUI.ShowObjectiveText(eightObjective.objectivesText);
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
            OnObj08Update?.Invoke(this, EventArgs.Empty);
        }
    }

    void CheckProgress()
    {
        if (hasTriggerBed)
        {
            if (DelayObjAfterComplete())
            {
                //LEVEL 2 COMPLETES HERE
                OnObj08Complete?.Invoke(this, EventArgs.Empty);
                PlayerPrefs.SetInt("Level03Unlock", 10);
                Destroy(gameObject, 2f);
            }
        }
    }

    private void OnDisable()
    {
        eventToHappenOnDisEnable?.Invoke();
    }
}
