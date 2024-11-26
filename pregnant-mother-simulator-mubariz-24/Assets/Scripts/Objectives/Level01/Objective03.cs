using UnityEngine;
using System;
using UnityEngine.Events;
public class Objective03 : MonoBehaviour
{
    [SerializeField] ObjectivesSO thirdObjectiveSO;
    [SerializeField] HintUI hintUI;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] GameObject levelCompletePanel;
    

    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    public static event EventHandler OnL01Obj03Update;
    public static event EventHandler OnL01Obj03Complete;

    int waterGlassTaken;
    int totalWaterGlassTaken = 2;
    float clock;
    Glass glass;

    private void OnEnable()
    {
        SFXmanager.Instance.PlaySoundEffectOnPosition(SFXmanager.Instance.objectiveUpdateSFX, Player.Instance.gameObject.transform.position);
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
        if (clock > 4f && clock < 4.5f)
        {
            OnL01Obj03Update?.Invoke(this, EventArgs.Empty);
        }
    }

    void CheckProgress()
    {
        if (waterGlassTaken >= totalWaterGlassTaken)
        {
            Debug.Log("level 1 is completed");
            thirdObjectiveSO.isObjectiveComplete = true;
            //LEVEL 01 ENDS HERE
            OnL01Obj03Complete?.Invoke(this, EventArgs.Empty);
            Time.timeScale = 0f;
            levelCompletePanel.SetActive(true);
        }
    }

    private void Glass_OnWaterDrunk(object sender, EventArgs e)
    {
        if (waterGlassTaken < 2)
        {
            waterGlassTaken++;
        }
    }

    

    private void OnDisable()
    {
        eventsToCallWhenDisable.Invoke();
    }
}
