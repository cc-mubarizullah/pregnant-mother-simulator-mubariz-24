using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective04 : MonoBehaviour
{
    [SerializeField] ObjectivesSO fourthObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] HintUI hintUI;
    
    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventToCallWhenDisAble;
    
    
    public static event EventHandler OnL02Obj01Update;
    public static event EventHandler OnL02Obj01Complete;

    float clock;
    bool interactedWithPhone;
    Telephone telePhone;

    private void Start()
    {
        telePhone = FindAnyObjectByType<Telephone>();
        telePhone.OnCallEnds += TelePhone_OnCallEnds;
    }

    private void Update()
    {
        objectiveShowUI.ShowObjectiveText(fourthObjectiveSO.objectivesText);
        DelayAfterActivation();
        CheckProgress();
    }
    private void TelePhone_OnCallEnds(object sender, System.EventArgs e)
    {
        interactedWithPhone = true;   // the only possibility to complete this mission
    }

    void CheckProgress()
    {
        if (interactedWithPhone)
        {
            //objective complete here
            OnL02Obj01Complete?.Invoke(this, EventArgs.Empty);
            Debug.Log("Mission Complete");
        }
    }
    void DelayAfterActivation()   // this function will be called bu update and corresponding objective will be shown after 4 sec
    {
        clock += Time.deltaTime;
        if (clock > 4f && clock < 4.5f)
        {
            OnL02Obj01Update?.Invoke(this, EventArgs.Empty);
        }
    }
    private void OnEnable()
    {
        eventsToCallWhenEnable.Invoke();
    }

    private void OnDisable()
    {
        eventToCallWhenDisAble.Invoke();        
    }
}
