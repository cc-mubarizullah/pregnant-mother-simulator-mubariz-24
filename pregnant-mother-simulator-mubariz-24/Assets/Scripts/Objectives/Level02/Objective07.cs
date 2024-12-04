using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective07 : MonoBehaviour
{
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] ObjectivesSO seventhObjective;

    public UnityEvent eventToHappenOnEnable;
    public UnityEvent eventToHappenOnDisEnable;

    public static event EventHandler OnObj07Update;
    public static event EventHandler OnObj07Complete;

    Glass glass;
    float clock;
    float clock2;

    bool hasDrunkWater;
    int waterGlassDrunkCount;
    int totalWaterGlassToDrink = 2;

    private void OnEnable()
    {
        eventToHappenOnEnable.Invoke();
    }
    private void Start()
    {
        glass = FindFirstObjectByType<Glass>();
        glass.OnWaterDrunk += Glass_OnWaterDrunk;
    }

    private void Update()
    {
        DelayObjUIAfterActivation();
        objectiveShowUI.ShowObjectiveText(seventhObjective.objectivesText);
        CheckProgress();
    }

    void DelayObjUIAfterActivation()   // this function will be called by update and corresponding objective will be shown after 4 sec
    {
        clock += Time.deltaTime;
        if (clock > 1f && clock < 1.1f)
        {
            OnObj07Update?.Invoke(this, EventArgs.Empty);
        }
    }

    void CheckProgress()
    {
        if (hasDrunkWater)
        {
            if (DelayObjAfterComplete())
            {
                //MISSION COMPLETE LOGIC HERE
                OnObj07Complete?.Invoke(this, EventArgs.Empty);
                Destroy(gameObject, 0.1f);
            }
        }
    }

    bool DelayObjAfterComplete()
    {
        clock2 += Time.deltaTime;
        if (clock2 >= 1f)
        {
            return true;
        }
        return false;
    }

    private void Glass_OnWaterDrunk(object sender, EventArgs e)
    {
        waterGlassDrunkCount++;
        if (waterGlassDrunkCount == totalWaterGlassToDrink)
        {
            hasDrunkWater = true;
        }
    }

    private void OnDisable()
    {
        eventToHappenOnDisEnable?.Invoke();
    }
}
