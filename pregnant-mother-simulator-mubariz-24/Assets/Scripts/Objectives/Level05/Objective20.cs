using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective20 : MonoBehaviour
{
    [SerializeField] ObjectivesSO tewnteenthObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] GameObject feederGameObject;
    [SerializeField] DropArea dropAreaComponentOfFeeder;
    [SerializeField] Transform playerPositionInHome;

    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    public static event EventHandler OnObj20Update;
    public static event EventHandler OnObj20Complete;

    bool hasPlacedFeeder;

    float clock;
    float clock2;

    private void OnEnable()
    {
        eventsToCallWhenEnable?.Invoke();
        Player.Instance.transform.position = playerPositionInHome.position;
    }

    private void Start()
    {
        feederGameObject.layer = 7;
        dropAreaComponentOfFeeder.OnBabyItemDropped += PlayerPlacedObject;
    }

    private void PlayerPlacedObject()
    {
        hasPlacedFeeder = true;
    }

    

    private void Update()
    {
        DelayAfterActivation();
        objectiveShowUI.ShowObjectiveText(tewnteenthObjectiveSO.objectivesText);
        CheckProgress();
    }

    void CheckProgress()
    {
        if (hasPlacedFeeder)
        {
            if (DelayAfterObjComplete())
            {
                {
                    //OBJECTIVE COMPLETE
                    OnObj20Complete?.Invoke(this, EventArgs.Empty);
                    Destroy(gameObject, 0.5f);
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
            OnObj20Update?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnDisable()
    {
        eventsToCallWhenDisable?.Invoke();
    }

}
