using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective21 : MonoBehaviour
{
    [SerializeField] ObjectivesSO tewentyOneObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] GameObject clothesGameObject;
    [SerializeField] DropArea dropAreaComponentOfClothes;

    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    public static event EventHandler OnObj21Update;
    public static event EventHandler OnObj21Complete;

    
    bool hasPlacedClothes;
    

    float clock;
    float clock2;

    private void OnEnable()
    {
        eventsToCallWhenEnable?.Invoke();
    }

    private void Start()
    {
        clothesGameObject.layer = 7;
        dropAreaComponentOfClothes.OnBabyItemDropped += PlayerPlacedObject;
    }

    
    private void PlayerPlacedObject()
    {
        hasPlacedClothes = true;
    }
    

    private void Update()
    {
        DelayAfterActivation();
        objectiveShowUI.ShowObjectiveText(tewentyOneObjectiveSO.objectivesText);
        CheckProgress();
    }

    void CheckProgress()
    {
        if (hasPlacedClothes)
        {
            if (DelayAfterObjComplete())
            {
                {
                    //OBJECTIVE COMPLETE
                    OnObj21Complete?.Invoke(this, EventArgs.Empty);
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
            OnObj21Update?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnDisable()
    {
        eventsToCallWhenDisable?.Invoke();
    }

}
