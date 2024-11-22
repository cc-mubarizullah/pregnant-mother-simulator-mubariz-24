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

    public UnityEvent eventToSubscribeOnEnable;
    public UnityEvent eventToSubscribeOnDisable;

    bool hasEatenWrongMedicine = false;

    Medicine[] medicines;
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
        CheckProgress();
        objectiveShowUI.ShowObjectiveText(secondObjectiveSO.objectivesText);
    }
    void CheckProgress()
    {
        if (medicineEaten == totalMedicineEaten)
        {
            secondObjectiveSO.isObjectiveComplete = true;
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        eventToSubscribeOnEnable?.Invoke();
    }
    private void OnDisable()
    {
        eventToSubscribeOnDisable?.Invoke();
    }

}
