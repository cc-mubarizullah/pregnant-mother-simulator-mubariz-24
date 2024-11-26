using UnityEngine;
using TMPro;
public class ObjectiveShowUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI objectiveTextUI;
    [Tooltip("This transform will hold the child of gameobject which holds the whole objective UI. In this the gameobject named emptyParent.")]

    [SerializeField] Animator m_Animator;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        Objective01.OnL01Obj01Complete += ObjectiveCompleteAnimation;
        Objective01.OnL01Obj01Update += ObjectiveUpdateAnimation;
        Objective02.OnL01Obj02Complete += ObjectiveCompleteAnimation;
        Objective02.OnL01Obj02Update += ObjectiveUpdateAnimation;
        Objective03.OnL01Obj03Complete += ObjectiveCompleteAnimation;
        Objective03.OnL01Obj03Update += ObjectiveUpdateAnimation;
        Objective04.OnL02Obj01Update += ObjectiveUpdateAnimation;
        Objective04.OnL02Obj01Complete += ObjectiveCompleteAnimation;

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
