using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective12 : MonoBehaviour
{
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] ObjectivesSO twelthObjective;
    [SerializeField] Objective12_TriggerUltrasound objective12_TriggerUltrasound;
    [SerializeField] GameObject ultrasoundCutscene;

    public UnityEvent eventToHappenOnEnable;
    public UnityEvent eventToHappenOnDisEnable;

    public static event EventHandler OnObj12Update;
    public static event EventHandler OnObj12Complete;

    float clock;
    float clock2;
    bool hasInteractedWithUltraSoundMachine;

    private void OnEnable()
    {
        eventToHappenOnEnable.Invoke();
    }

    private void Start()
    {
        objective12_TriggerUltrasound.OnPlayerTriggerUltraSoundMachine += Objective12_TriggerUltrasound_OnPlayerTriggerUltraSoundMachine;
    }

    private void Objective12_TriggerUltrasound_OnPlayerTriggerUltraSoundMachine()
    {
        hasInteractedWithUltraSoundMachine = true;
    }

    private void Update()
    {
        DelayObjUIAfterActivation();
        CheckProgress();
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

    void CheckProgress()
    {
        if (hasInteractedWithUltraSoundMachine)
        {
            if (DelayObjAfterComplete())
            {
                ultrasoundCutscene.SetActive(true);
                OnObj12Complete?.Invoke(this, EventArgs.Empty);
            }


        }
    }


    private void OnDisable()
    {
        eventToHappenOnDisEnable?.Invoke();
    }
}
