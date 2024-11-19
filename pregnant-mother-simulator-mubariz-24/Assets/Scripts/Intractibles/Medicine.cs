using System;
using UnityEngine;

public class Medicine : MonoBehaviour, IInteractWithIneractables
{
    [SerializeField] IntractiblesSO intractiblesSO;

    enum MedicineType
    {
        Good,
        Harmful
    }

    [SerializeField] MedicineType medicineType;

    public void Interact()
    {
        ShowItemText();
    }
    
    void ShowItemText()
    {
        InteractiveItemTextUI.Instance.SetItemTextFromSO(intractiblesSO);
    }


    public void PhysicalInteract()
    {
        switch (medicineType)
        {
            case MedicineType.Good:

                if (BabyHealthBarUI.Instance.currentBabyHealth < 94)
                {
                    BabyHealthBarUI.Instance.UpdateBabyHealthUI(GameManager.Instance.healthGainedbyRightAction);
                }

                break;
            case MedicineType.Harmful:

                if (BabyHealthBarUI.Instance.currentBabyHealth > 0)
                {
                    BabyHealthBarUI.Instance.UpdateBabyHealthUI(GameManager.Instance.healthLooseByWrongAction);
                }

                break;
        }
        Destroy(gameObject);
    }
}
