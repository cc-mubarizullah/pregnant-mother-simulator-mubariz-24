using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective12 : MonoBehaviour
{
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] ObjectivesSO twelthObjective;

    public UnityEvent eventToHappenOnEnable;
    public UnityEvent eventToHappenOnDisEnable;

    public static event EventHandler OnObj12Update;
    public static event EventHandler OnObj12Complete;

    float clock;
    float clock2;
    bool hasInteractedWithDoctor;

    private void OnEnable()
    {
        eventToHappenOnEnable.Invoke();

    }

    private void Start()
    {

    }



    private void Update()
    {
        DelayObjUIAfterActivation();
        //CheckProgress();
        objectiveShowUI.ShowObjectiveText(twelthObjective.objectivesText);
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
            OnObj12Update?.Invoke(this, EventArgs.Empty);
        }
    }

    //void CheckProgress()
    //{
    //    //if (hasTriggerBed)
    //    //{
    //    if (DelayObjAfterComplete())
    //    {
    //        //LEVEL 2 COMPLETES HERE
    //        OnObj12Complete?.Invoke(this, EventArgs.Empty);
    //        Debug.Log("Level 2 completes here");

    //    }
    //    //}
    //}

    private void OnDisable()
    {
        eventToHappenOnDisEnable?.Invoke();
    }
}
