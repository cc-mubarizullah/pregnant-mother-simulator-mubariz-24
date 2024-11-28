using System;
using UnityEditor.Media;
using UnityEngine;
using UnityEngine.Events;

public class Objective05 : MonoBehaviour
{
    [SerializeField] ObjectivesSO fifthObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;

    public static event EventHandler OnObj05Update;
    public static event EventHandler OnObj05Complete;

    public UnityEvent eventsToHappenWhenOnEnable;
    public UnityEvent eventsToHappenWhenOnDisable;

    bool interactedWithMedicalRecod;
    float clock;
    float clock2;
    MedicalRecord medicalRecord;
    private void OnEnable()
    {
        eventsToHappenWhenOnEnable?.Invoke();
    }
    private void Start()
    {
        medicalRecord = FindFirstObjectByType<MedicalRecord>();
        medicalRecord.gameObject.layer = 7;    // set the medicalReport to be interactive(layer 07)
        medicalRecord.OnGrabReport = MedicalRecord_OnGrabReport;
    }
    private void Update()
    {
        DelayObjUIAfterActivation();
        objectiveShowUI.ShowObjectiveText(fifthObjectiveSO.objectivesText);
        CheckProgress();
    }

    void CheckProgress()
    {
        if (interactedWithMedicalRecod)
        {
            if (Delay())
            {
                //objective complete here
                OnObj05Complete?.Invoke(this, EventArgs.Empty);
                fifthObjectiveSO.isObjectiveComplete = true;
                Destroy(gameObject, 0.1f);
            }
        }
    }
    void DelayObjUIAfterActivation()   // this function will be called by update and corresponding objective will be shown after 4 sec
    {
        clock += Time.deltaTime;
        if (clock > 2f && clock < 2.1f)
        {
            OnObj05Update?.Invoke(this, EventArgs.Empty);
        }
    }

    bool Delay()
    {
        clock2 += Time.deltaTime;
        if (clock2 >= 2f)
        {
            return true;
        }
        return false;
    }
    void MedicalRecord_OnGrabReport()
    {
        interactedWithMedicalRecod = true;
    }

    private void OnDisable()
    {
        eventsToHappenWhenOnDisable.Invoke();
    }
}
