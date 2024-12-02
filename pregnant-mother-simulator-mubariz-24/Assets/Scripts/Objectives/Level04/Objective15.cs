using System;
using UnityEngine;
using UnityEngine.Events;

public class Objective15 : MonoBehaviour
{
    [SerializeField] ObjectivesSO fifteenthObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] HintUI hintUI;
    [SerializeField] string eatingWrongMedicineWarning;
    int medicineEaten;
    int totalMedicineEaten = 2;

    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    public static event EventHandler OnObj15Update;
    public static event EventHandler OnObj15Complete;

    bool hasEatenWrongMedicine = false;

    Medicine[] medicines;
    Medicine[] medicineLeft;
    bool hasEatenAllMedicine;
    float clock;
    float clock2;

    private void OnEnable()
    {
        eventsToCallWhenEnable?.Invoke();
    }

    private void Start()
    {
        medicines = FindObjectsByType<Medicine>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach (Medicine item in medicines)
        {
            item.gameObject.layer = 7;
            item.OnEatingRightMedicine += Item_OnEatingRightMedicine;
            item.OnEatingWrongMedicine += Item_OnEatingWrongMedicine;
        }
    }


    private void Update()
    {
        CheckingAllMedicine();
        DelayAfterActivation();
        CheckProgress();
        objectiveShowUI.ShowObjectiveText(fifteenthObjectiveSO.objectivesText);
    }

    void CheckingAllMedicine()
    {
        medicineLeft = FindObjectsByType<Medicine>(FindObjectsInactive.Include, FindObjectsSortMode.None);
    }

    void DelayAfterActivation()
    {
        clock += Time.deltaTime;
        if (clock > 2f && clock < 2.1f)
        {
            OnObj15Update?.Invoke(this, EventArgs.Empty);
        }
    }

    //Logic for objective complete
    void CheckProgress()
    {
        if (hasEatenAllMedicine)
        {
            if (DelayAfterObjectiveComplete())
            {
                //OBJECTIVE COMPLETE
                fifteenthObjectiveSO.isObjectiveComplete = true;
                OnObj15Complete?.Invoke(this, EventArgs.Empty);
                Destroy(gameObject, 1f);
            }
        }
    }


    bool DelayAfterObjectiveComplete()
    {
        clock2 += Time.deltaTime;
        if (clock2 >= 2f)
        {
            return true;
        }
        return false;
    }

    private void Item_OnEatingWrongMedicine(object sender, System.EventArgs e)   //function to trigger warning for the first time to not eat unhealthy items
    {
        if (!hasEatenWrongMedicine)
        {
            hintUI.gameObject.SetActive(true);
            SFXmanager.Instance.PlaySoundEffectOnPosition(SFXmanager.Instance.errorSFX, Player.Instance.transform.position);
            hintUI.ShowHintText(eatingWrongMedicineWarning);
            hasEatenWrongMedicine = true;
        }
    }

    private void Item_OnEatingRightMedicine(object sender, System.EventArgs e) // fucntion to increment the progress when player eats healthy
    {
        if (medicineEaten < totalMedicineEaten)
        {
            medicineEaten++;
        }
        if (medicineEaten == totalMedicineEaten)
        {
            hasEatenAllMedicine = true;
        }
    }


    private void OnDisable()
    {
        eventsToCallWhenDisable?.Invoke();
        foreach (Medicine item in medicineLeft)
        {
            if (item != null)
            {
                item.gameObject.layer = 0;
            }
        }
    }


}
