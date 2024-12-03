using UnityEngine;
using UnityEngine.Events;
using System;

public class Objective17 : MonoBehaviour
{
    [SerializeField] ObjectivesSO seventeethObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    ToysToGather[] toysToGather;
    [SerializeField] GameObject toyBoxGO;
    ToyBox toyBox;

    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    public static event EventHandler OnObj17Update;
    public static event EventHandler OnObj17Complete;

    int toysGathered;
    int totalToys;
    bool hasCollectedAllToys;
    bool hasPuttedInBox;

    float clock;
    float clock2;

    private void OnEnable()
    {
        eventsToCallWhenEnable?.Invoke();
    }

    private void Start()
    {
        toysToGather = FindObjectsByType<ToysToGather>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (ToysToGather obj in toysToGather)
        {
            obj.gameObject.layer = 7;
            obj.OnToyGather += Obj_OnToyGather;
        }
         totalToys = toysToGather.Length;

        toyBox = toyBoxGO.GetComponent<ToyBox>();
        toyBox.OnPutInBox += ToyBox_OnPutInBox;
    }

    private void ToyBox_OnPutInBox()
    {
        hasPuttedInBox = true;
    }

    private void Obj_OnToyGather()
    {
        if(toysGathered < totalToys)
            toysGathered++;

        if (toysGathered ==totalToys)
        {
            hasCollectedAllToys = true;
            toyBoxGO.layer = 7;
        }
    }

    private void Update()
    {
        DelayAfterActivation();
        objectiveShowUI.ShowObjectiveText(seventeethObjectiveSO.objectivesText);
        CheckProgress();
    }

    void CheckProgress()
    {
        if (hasPuttedInBox && hasCollectedAllToys)
        {
            if (DelayAfterObjComplete())
            {
                {
                    //OBJECTIVE COMPLETE
                    OnObj17Complete?.Invoke(this, EventArgs.Empty);
                    toyBoxGO.layer = 0;
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
            OnObj17Update?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnDisable()
    {
        eventsToCallWhenDisable?.Invoke();
    }

}
