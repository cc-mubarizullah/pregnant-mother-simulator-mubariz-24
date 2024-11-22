using UnityEngine;
using System;
using UnityEngine.Events;
public class ThirdObjective : MonoBehaviour
{
    [SerializeField] ObjectivesSO thirdObjectiveSO;
    [SerializeField] HintUI hintUI;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] GameObject levelCompletePanel;

    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    int waterGlassTaken;
    int totalWaterGlassTaken = 2;

    private void Update()
    {
        if(waterGlassTaken >= totalWaterGlassTaken)
        {
            Debug.Log("level 1 is completed");
            Time.timeScale = 0f;
            

        }    
    }
    
    
}
