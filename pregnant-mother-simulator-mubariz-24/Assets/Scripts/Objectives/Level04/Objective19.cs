using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective19 : MonoBehaviour
{
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] ObjectivesSO nineteenthObjective;
    [SerializeField] GameObject sleepingTransitionImageGO;


    public UnityEvent eventToHappenOnEnable;
    public UnityEvent eventToHappenOnDisEnable;

    public static event EventHandler OnObj19Update;
    public static event EventHandler OnObj19Complete;

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
        objectiveShowUI.ShowObjectiveText(nineteenthObjective.objectivesText);
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
        if (clock > 2f && clock < 2.1f)
        {
            OnObj19Update?.Invoke(this, EventArgs.Empty);
        }
    }

    void CheckProgress()
    {
        if (hasTriggerBed)
        {
            if (DelayObjAfterComplete())
            {
                //LEVEL 2 COMPLETES HERE
                OnObj19Complete?.Invoke(this, EventArgs.Empty);
                Destroy(gameObject, 0.5f);
                PlayerPrefs.SetInt("Level05Unlock", 10);

            }
        }
    }

    private void OnDisable()
    {
        eventToHappenOnDisEnable?.Invoke();
    }
}
