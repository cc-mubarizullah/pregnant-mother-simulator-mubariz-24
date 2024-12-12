using System;
using UnityEngine;

public class Medicine : MonoBehaviour, IInteractWithIneractables
{
    [SerializeField] IntractiblesSO intractiblesSO;
    public event EventHandler OnEatingRightMedicine;
    public event EventHandler OnEatingWrongMedicine;

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
        SFXmanager.Instance.PlayRandomSoundEffectOnPosition(SFXmanager.Instance.swallowFood1, SFXmanager.Instance.swallowFood2, Player.Instance.transform.position, 1f);
        switch (medicineType)
        {
            case MedicineType.Good:

                if (BabyHealthBarUI.Instance.currentBabyHealth < 94)
                {
                    BabyHealthBarUI.Instance.UpdateBabyHealthUI(PrefrencesManager.Instance.healthGainedbyRightAction);
                    OnEatingRightMedicine?.Invoke(this, EventArgs.Empty);
                }

                break;
            case MedicineType.Harmful:

                if (BabyHealthBarUI.Instance.currentBabyHealth > 0)
                {
                    BabyHealthBarUI.Instance.UpdateBabyHealthUI(PrefrencesManager.Instance.healthLooseByWrongAction);
                    OnEatingWrongMedicine?.Invoke(this, EventArgs.Empty);
                }

                break;
        }
        Destroy(gameObject);
    }
}
