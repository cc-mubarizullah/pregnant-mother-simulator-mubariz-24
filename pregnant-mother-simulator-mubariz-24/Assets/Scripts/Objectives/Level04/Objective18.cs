using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective18 : MonoBehaviour
{
    [SerializeField] ObjectivesSO eighteenthObjectiveSO;
    [SerializeField] HintUI hintUI;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] GameObject levelCompletePanel;


    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    public static event EventHandler OnObj18Update;
    public static event EventHandler OnObj18Complete;

    int waterGlassTaken;
    int totalWaterGlassTaken = 2;
    bool hasDrunkWater;
    float clock;
    float clock2;
    Glass glass;

    private void OnEnable()
    {
        eventsToCallWhenEnable.Invoke();
    }

    private void Start()
    {
        glass = FindAnyObjectByType<Glass>();
        glass.OnWaterDrunk += Glass_OnWaterDrunk;
    }

    private void Update()
    {
        CheckProgress();
        DelayAfterActivation();
        objectiveShowUI.ShowObjectiveText(eighteenthObjectiveSO.objectivesText);
    }

    void DelayAfterActivation()
    {
        clock += Time.deltaTime;
        if (clock > 2f && clock < 2.1f)
        {
            OnObj18Update?.Invoke(this, EventArgs.Empty);
        }
    }

    void CheckProgress()
    {
        if (hasDrunkWater)
        {
            if (DelayAfterObjComplete())
            {
                Debug.Log("level 1 is completed");
                eighteenthObjectiveSO.isObjectiveComplete = true;
                //LEVEL 01 ENDS HERE
                OnObj18Complete?.Invoke(this, EventArgs.Empty);
                //Time.timeScale = 0f;
                //levelCompletePanel.SetActive(true);
                Destroy(gameObject, 0.1f);

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


    private void Glass_OnWaterDrunk(object sender, EventArgs e)
    {
        if (waterGlassTaken < 2)
        {
            waterGlassTaken++;
            SFXmanager.Instance.PlaySoundEffectOnPosition(SFXmanager.Instance.waterDrinkSFX, Player.Instance.transform.position);
        }
        if (waterGlassTaken >= totalWaterGlassTaken)
        {
            hasDrunkWater = true;
        }
    }

    private void OnDisable()
    {
        eventsToCallWhenDisable.Invoke();
    }
}
