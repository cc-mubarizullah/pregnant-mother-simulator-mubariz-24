using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SecondObjective : MonoBehaviour
{
    [SerializeField] ObjectivesSO secondObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] HintUI hintUI;
    [SerializeField] string eatingWrongMedicineWarning;
    int medicineEaten;
    int totalMedicineEaten = 3;

    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    public static event EventHandler OnL01Obj02Update;
    public static event EventHandler OnL01Obj02Complete;

    bool hasEatenWrongMedicine = false;

    Medicine[] medicines;
    float clock;
    private void Start()
    {
        medicines = FindObjectsByType<Medicine>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (Medicine item in medicines)
        {
            item.OnEatingRightMedicine += Item_OnEatingRightMedicine;
            item.OnEatingWrongMedicine += Item_OnEatingWrongMedicine;
        }
    }

    private void Item_OnEatingWrongMedicine(object sender, System.EventArgs e)
    {
        if (!hasEatenWrongMedicine)
        {
            hintUI.gameObject.SetActive(true);
            hintUI.ShowHintText(eatingWrongMedicineWarning);
            hasEatenWrongMedicine = true;
        }
    }

    private void Item_OnEatingRightMedicine(object sender, System.EventArgs e)
    {
        if (medicineEaten < totalMedicineEaten)
        {
            medicineEaten++;
        } 
    }

    private void Update()
    {
        DelayAfterActivation();
        CheckProgress();
        objectiveShowUI.ShowObjectiveText(secondObjectiveSO.objectivesText);
    }
    //Logic for objective complete
    void CheckProgress()
    {
        if (medicineEaten == totalMedicineEaten)
        {
            //OBJECTIVE COMPLETE
            secondObjectiveSO.isObjectiveComplete = true;
            OnL01Obj02Complete?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject, 1f);
        }
    }

    private void OnEnable()
    {
        SFXmanager.Instance.PlaySoundEffectOnPosition(SFXmanager.Instance.objectiveUpdateSFX, Player.Instance.gameObject.transform.position);
        eventsToCallWhenEnable?.Invoke();
    }
    private void OnDisable()
    {
        eventsToCallWhenDisable?.Invoke();
    }
    void DelayAfterActivation()
    {
        clock += Time.deltaTime;
        if (clock > 4f && clock < 4.5f)
        {
            OnL01Obj02Update?.Invoke(this, EventArgs.Empty);
        }
    }
}
