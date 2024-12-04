using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective25 : MonoBehaviour
{
    [SerializeField] ObjectivesSO tewentyFiveObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] GameObject babyBagGameObject;
    [SerializeField] DropArea dropAreaComponentOfBabyBag;

    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    public static event EventHandler OnObj25Update;
    public static event EventHandler OnObj25Complete;


    bool hasPlacedDiaper;


    float clock;
    float clock2;

    private void OnEnable()
    {
        eventsToCallWhenEnable?.Invoke();
    }

    private void Start()
    {
        babyBagGameObject.layer = 7;
        dropAreaComponentOfBabyBag.OnBabyItemDropped += PlayerPlacedObject;
    }


    private void PlayerPlacedObject()
    {
        hasPlacedDiaper = true;
    }


    private void Update()
    {
        DelayAfterActivation();
        objectiveShowUI.ShowObjectiveText(tewentyFiveObjectiveSO.objectivesText);
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
                    OnObj25Complete?.Invoke(this, EventArgs.Empty);
                    Destroy(gameObject);

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
            OnObj25Update?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnDisable()
    {
        eventsToCallWhenDisable?.Invoke();
    }

}
