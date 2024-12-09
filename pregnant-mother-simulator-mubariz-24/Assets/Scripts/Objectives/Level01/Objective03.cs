using UnityEngine;
using System;
using UnityEngine.Events;
public class Objective03 : MonoBehaviour
{
    [SerializeField] ObjectivesSO thirdObjectiveSO;
    [SerializeField] HintUI hintUI;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    

    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    public static event EventHandler OnObj03Update;
    public static event EventHandler OnObj03Complete;

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
        objectiveShowUI.ShowObjectiveText(thirdObjectiveSO.objectivesText);
    }

    void DelayAfterActivation()
    {
        clock += Time.deltaTime;
        if (clock > 2f && clock < 2.1f)
        {
            OnObj03Update?.Invoke(this, EventArgs.Empty);
        }
    }

    void CheckProgress()
    {
        if (hasDrunkWater)
        {
            if (DelayAfterObjComplete())
            {
                thirdObjectiveSO.isObjectiveComplete = true;
                //LEVEL 01 ENDS HERE
                OnObj03Complete?.Invoke(this, EventArgs.Empty);
                //Time.timeScale = 0f;
                //levelCompletePanel.SetActive(true);
                Destroy(gameObject, 0.1f);

                //SEND MESSAGE HERE TO LEVEL01 TO SAVE THINGS TILL THIS
                PlayerPrefs.SetInt("Level02Unlock", 10);
            }
        }
    }

    bool DelayAfterObjComplete()
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
