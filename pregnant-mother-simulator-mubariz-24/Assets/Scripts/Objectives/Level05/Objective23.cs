using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective23 : MonoBehaviour
{
    [SerializeField] ObjectivesSO tewentyThreeObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] GameObject diaperGameObject;
    [SerializeField] DropArea dropAreaComponentOfDiaper;


    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    public static event EventHandler OnObj23Update;
    public static event EventHandler OnObj23Complete;


    bool hasPlacedDiaper;


    float clock;
    float clock2;

    private void OnEnable()
    {
        eventsToCallWhenEnable?.Invoke();
    }

    private void Start()
    {
        diaperGameObject.layer = 7;
        dropAreaComponentOfDiaper.OnBabyItemDropped += PlayerPlacedObject;
    }


    private void PlayerPlacedObject()
    {
        hasPlacedDiaper = true;
    }


    private void Update()
    {
        DelayAfterActivation();
        objectiveShowUI.ShowObjectiveText(tewentyThreeObjectiveSO.objectivesText);
        CheckProgress();
    }

    void CheckProgress()
    {
        if (hasPlacedDiaper)
        {
            if (DelayAfterObjComplete())
            {
                {
                    //OBJECTIVE COMPLETE
                    OnObj23Complete?.Invoke(this, EventArgs.Empty);
                    Destroy(gameObject);
                    PlayerPrefs.SetInt("Level06Unlock", 10);
                }
            }
        }
    }
    bool DelayAfterObjComplete()
    {
        clock2 += Time.deltaTime;
        if (clock2 >= 2f)
        {
            return true;
        }
        return false;
    }

    void DelayAfterActivation()     // this function will fire event that objective ui will listen and show objective animation
    {
        clock += Time.deltaTime;
        if (clock > 2f && clock < 2.1f)
        {
            OnObj23Update?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnDisable()
    {
        eventsToCallWhenDisable?.Invoke();
    }

}
