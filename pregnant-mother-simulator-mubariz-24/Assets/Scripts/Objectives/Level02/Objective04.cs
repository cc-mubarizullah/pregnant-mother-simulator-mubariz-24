using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective04 : MonoBehaviour
{
    [SerializeField] ObjectivesSO fourthObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    
    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventToCallWhenDisAble;
    
    
    public static event EventHandler OnObj04Update;
    public static event EventHandler OnObj04Complete;

    float clock2;
    float clock;
    bool interactedWithPhone;
    Telephone telePhone;
    private void OnEnable()
    {
        eventsToCallWhenEnable.Invoke();
    }


    private void Start()
    {
        telePhone = FindAnyObjectByType<Telephone>();
        telePhone.gameObject.layer = 7;       // set telephone interactive 
        telePhone.OnCallEnds += TelePhone_OnCallEnds;
    }

    private void Update()
    {
        objectiveShowUI.ShowObjectiveText(fourthObjectiveSO.objectivesText);
        DelayObjAfterActivation();
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
            if (Delay())
            {
                //objective complete here
                OnObj04Complete?.Invoke(this, EventArgs.Empty);
                fourthObjectiveSO.isObjectiveComplete = true;
                Destroy(gameObject, 0.1f);
            }
        }
    }
    void DelayObjAfterActivation()   // this function will be called bu update and corresponding objective will be shown after 4 sec
    {
        clock += Time.deltaTime;
        if (clock > 2f && clock < 2.1f)
        {
            OnObj04Update?.Invoke(this, EventArgs.Empty);
        }
    }
    bool Delay()   
    {
        clock2 += Time.deltaTime;
        if (clock2 > 2f)
        {
            return true;
        }
        return false;
    }
    
    private void OnDisable()
    {
        eventToCallWhenDisAble.Invoke();
        telePhone.gameObject.layer = 0;       // set telephone non-interactive again
    }
}
