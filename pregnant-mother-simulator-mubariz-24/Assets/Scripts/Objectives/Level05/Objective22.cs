using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective22 : MonoBehaviour
{
    [SerializeField] ObjectivesSO tewentyTwoObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] GameObject blanketGameObject;
    [SerializeField] DropArea dropAreaComponentOfBlanket;

    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    public static event EventHandler OnObj22Update;
    public static event EventHandler OnObj22Complete;


    bool hasPlacedBlanket;


    float clock;
    float clock2;

    private void OnEnable()
    {
        eventsToCallWhenEnable?.Invoke();
    }

    private void Start()
    {
        blanketGameObject.layer = 7;
        dropAreaComponentOfBlanket.OnBabyItemDropped += PlayerPlacedObject;
    }


    private void PlayerPlacedObject()
    {
        hasPlacedBlanket = true;
    }


    private void Update()
    {
        DelayAfterActivation();
        objectiveShowUI.ShowObjectiveText(tewentyTwoObjectiveSO.objectivesText);
        CheckProgress();
    }

    void CheckProgress()
    {
        if (hasPlacedBlanket)
        {
            if (DelayAfterObjComplete())
            {
                {
                    //OBJECTIVE COMPLETE
                    OnObj22Complete?.Invoke(this, EventArgs.Empty);
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
            OnObj22Update?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnDisable()
    {
        eventsToCallWhenDisable?.Invoke();
    }

}
