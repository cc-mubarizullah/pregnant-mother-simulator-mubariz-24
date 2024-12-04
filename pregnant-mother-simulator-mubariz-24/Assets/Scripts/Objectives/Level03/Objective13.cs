using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective13 : MonoBehaviour
{
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] ObjectivesSO thirteenObjective;
    [SerializeField] Objective13_Trigger objective13_Trigger;
    [SerializeField] GameObject reportInHand;
    [SerializeField] GameObject reportOnTable;

    public UnityEvent eventToHappenOnEnable;
    public UnityEvent eventToHappenOnDisEnable;

    public static event EventHandler OnObj13Update;
    public static event EventHandler OnObj13Complete;

    float clock;
    float clock2;

    bool hasVisitedDoctor;

    private void OnEnable()
    {
        eventToHappenOnEnable.Invoke();
    }

    private void Start()
    {
        objective13_Trigger.OnPlayerTriggDocTable += Objective13_Trigger_OnPlayerTriggDocTable;
    }

    private void Objective13_Trigger_OnPlayerTriggDocTable()
    {
        reportInHand.SetActive(true);
        reportOnTable.SetActive(false);
        hasVisitedDoctor = true;
    }

    private void Update()
    {
        DelayObjUIAfterActivation();
        CheckProgress();
        objectiveShowUI.ShowObjectiveText(thirteenObjective.objectivesText);
    }

    bool DelayObjAfterComplete()
    {
        clock2 += Time.deltaTime;
        if (clock2 >= 0.5f)
        {
            return true;
        }
        return false;
    }
    void DelayObjUIAfterActivation()   // this function will be called by update and corresponding objective will be shown after 4 sec
    {
            clock += Time.deltaTime;
        if (clock > 1f && clock < 1.1f)
        {
            OnObj13Update?.Invoke(this, EventArgs.Empty);
        }
    }

    void CheckProgress()
    {
        if (hasVisitedDoctor)
        {
            if (DelayObjAfterComplete())
            {
                OnObj13Complete?.Invoke(this, EventArgs.Empty);
                PlayerPrefs.SetInt("Level04Unlock", 10);
                Destroy(gameObject);
            }
        }
    }


    private void OnDisable()
    {
        eventToHappenOnDisEnable?.Invoke();
    }
}
