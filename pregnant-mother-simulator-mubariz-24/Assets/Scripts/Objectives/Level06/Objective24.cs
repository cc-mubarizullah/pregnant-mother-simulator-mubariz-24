using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective24 : MonoBehaviour
{
    [SerializeField] ObjectivesSO tewentyFourObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] GameObject suppliesGameObject;
    [SerializeField] DropArea dropAreaComponentOfSupplies;
    [SerializeField] Transform playerPositionInHome;

    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    public static event EventHandler OnObj24Update;
    public static event EventHandler OnObj24Complete;


    bool hasPlacedDiaper;


    float clock;
    float clock2;

    private void OnEnable()
    {
        eventsToCallWhenEnable?.Invoke();
        Player.Instance.transform.position = playerPositionInHome.position;
    }

    private void Start()
    {
        suppliesGameObject.layer = 7;
        dropAreaComponentOfSupplies.OnBabyItemDropped += PlayerPlacedObject;
    }


    private void PlayerPlacedObject()
    {
        hasPlacedDiaper = true;
    }


    private void Update()
    {
        DelayAfterActivation();
        objectiveShowUI.ShowObjectiveText(tewentyFourObjectiveSO.objectivesText);
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
                    OnObj24Complete?.Invoke(this, EventArgs.Empty);
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
            OnObj24Update?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnDisable()
    {
        eventsToCallWhenDisable?.Invoke();
    }

}
