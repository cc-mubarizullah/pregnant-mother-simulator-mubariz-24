using UnityEngine;
using TMPro;
public class ObjectiveShowUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI objectiveTextUI;
    [Tooltip("This transform will hold the child of gameobject which holds the whole objective UI. In this the gameobject named emptyParent.")]
    [SerializeField] Transform child;
    [SerializeField] Animator m_Animator;
    [SerializeField] FirstObjectiveManager firstObjectiveManager;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        FirstObjectiveManager.OnL01Obj01Complete += ObjectiveCompleteAnimation;
        FirstObjectiveManager.OnL01Obj01Update += ObjectiveUpdateAnimation;
        SecondObjective.OnL01Obj02Complete += ObjectiveCompleteAnimation;
        SecondObjective.OnL01Obj02Update += ObjectiveUpdateAnimation;
        ThirdObjective.OnL01Obj03Complete += ObjectiveCompleteAnimation;
        ThirdObjective.OnL01Obj03Update += ObjectiveUpdateAnimation;

    }

    private void ObjectiveUpdateAnimation(object sender, System.EventArgs e)
    {
        m_Animator.SetBool("isObjComplete", true);
    }

    private void ObjectiveCompleteAnimation(object sender, System.EventArgs e)
    {
        m_Animator.SetBool("isObjComplete", false);
    }

    public void ShowObjectiveText(string objectiveToShow)
    {
        objectiveTextUI.text = objectiveToShow;
    }

    public void ObjectiveUpdateSFX()
    {
        SFXmanager.Instance.PlaySoundEffectOnPosition(SFXmanager.Instance.objectiveUpdateSFX, Camera.main.transform.position);
    }

    public void ObjectiveCompleteSFX()
    {
        SFXmanager.Instance.PlaySoundEffectOnPosition(SFXmanager.Instance.objectiveCompleteSFX, Camera.main.transform.position);
    }

}
