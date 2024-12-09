using UnityEngine;
using TMPro;
public class ObjectiveShowUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI objectiveTextUI;
    [Tooltip("This transform will hold the child of gameobject which holds the whole objective UI. In this the gameobject named emptyParent.")]



    [SerializeField] Animator m_Animator;
    private void OnEnable()
    {
        m_Animator = GetComponent<Animator>();
        Objective01.OnObj01Complete += ObjectiveCompleteAnimation;
        Objective01.OnObj01Update += ObjectiveUpdateAnimation;
        Objective02.OnObj02Complete += ObjectiveCompleteAnimation;
        Objective02.OnObj02Update += ObjectiveUpdateAnimation;
        Objective03.OnObj03Complete += ObjectiveCompleteAnimation;
        Objective03.OnObj03Update += ObjectiveUpdateAnimation;
        Objective04.OnObj04Update += ObjectiveUpdateAnimation;
        Objective04.OnObj04Complete += ObjectiveCompleteAnimation;
        Objective05.OnObj05Update += ObjectiveUpdateAnimation;
        Objective05.OnObj05Complete += ObjectiveCompleteAnimation;
        Objective06.OnObj06Update += ObjectiveUpdateAnimation;
        Objective06.OnObj06Complete += ObjectiveCompleteAnimation;
        Objective07.OnObj07Update += ObjectiveUpdateAnimation;
        Objective07.OnObj07Complete += ObjectiveCompleteAnimation;
        Objective08.OnObj08Update += ObjectiveUpdateAnimation;
        Objective08.OnObj08Complete += ObjectiveCompleteAnimation;
        Objective09.OnObj09Update += ObjectiveUpdateAnimation;
        Objective09.OnObj09Complete += ObjectiveCompleteAnimation;
        Objective10.OnObj10Update += ObjectiveUpdateAnimation;
        Objective10.OnObj10Complete += ObjectiveCompleteAnimation;
        Objective11.OnObj11Update += ObjectiveUpdateAnimation;
        Objective11.OnObj11Complete += ObjectiveCompleteAnimation;
        Objective12.OnObj12Update += ObjectiveUpdateAnimation;
        Objective12.OnObj12Complete += ObjectiveCompleteAnimation; 
        Objective13.OnObj13Update += ObjectiveUpdateAnimation;
        Objective13.OnObj13Complete += ObjectiveCompleteAnimation;
        Objective14.OnObj14Update += ObjectiveUpdateAnimation;
        Objective14.OnObj14Complete += ObjectiveCompleteAnimation;
        Objective15.OnObj15Update += ObjectiveUpdateAnimation;
        Objective15.OnObj15Complete += ObjectiveCompleteAnimation;
        Objective16.OnObj16Update += ObjectiveUpdateAnimation;
        Objective16.OnObj16Complete += ObjectiveCompleteAnimation;
        Objective17.OnObj17Update += ObjectiveUpdateAnimation;
        Objective17.OnObj17Complete += ObjectiveCompleteAnimation;
        Objective18.OnObj18Update += ObjectiveUpdateAnimation;
        Objective18.OnObj18Complete += ObjectiveCompleteAnimation;
        Objective19.OnObj19Update += ObjectiveUpdateAnimation;
        Objective19.OnObj19Complete += ObjectiveCompleteAnimation;
        Objective20.OnObj20Update += ObjectiveUpdateAnimation;
        Objective20.OnObj20Complete += ObjectiveCompleteAnimation;
        Objective21.OnObj21Update += ObjectiveUpdateAnimation;
        Objective21.OnObj21Complete += ObjectiveCompleteAnimation;
        Objective22.OnObj22Update += ObjectiveUpdateAnimation;
        Objective22.OnObj22Complete += ObjectiveCompleteAnimation;
        Objective23.OnObj23Update += ObjectiveUpdateAnimation;
        Objective23.OnObj23Complete += ObjectiveCompleteAnimation;
        Objective24.OnObj24Update += ObjectiveUpdateAnimation;
        Objective24.OnObj24Complete += ObjectiveCompleteAnimation;
        Objective25.OnObj25Update += ObjectiveUpdateAnimation;
        Objective25.OnObj25Complete += ObjectiveCompleteAnimation;
        Objecitive26.OnObj26Update += ObjectiveUpdateAnimation;
        Objecitive26.OnObj26Complete += ObjectiveCompleteAnimation;
        Objective27.OnObj27Update += ObjectiveUpdateAnimation;
        Objective27.OnObj27Complete += ObjectiveCompleteAnimation;
        Objective28.OnObj28Update += ObjectiveUpdateAnimation;
        Objective28.OnObj28Complete += ObjectiveCompleteAnimation;

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

    private void OnDisable()
    {
        Objective01.OnObj01Complete -= ObjectiveCompleteAnimation;
        Objective01.OnObj01Update -= ObjectiveUpdateAnimation;
        Objective02.OnObj02Complete -= ObjectiveCompleteAnimation;
        Objective02.OnObj02Update -= ObjectiveUpdateAnimation;
        Objective03.OnObj03Complete -= ObjectiveCompleteAnimation;
        Objective03.OnObj03Update -= ObjectiveUpdateAnimation;
        Objective04.OnObj04Update -= ObjectiveUpdateAnimation;
        Objective04.OnObj04Complete -= ObjectiveCompleteAnimation;
        Objective05.OnObj05Update -= ObjectiveUpdateAnimation;
        Objective05.OnObj05Complete -= ObjectiveCompleteAnimation;
        Objective06.OnObj06Update -= ObjectiveUpdateAnimation;
        Objective06.OnObj06Complete -= ObjectiveCompleteAnimation;
        Objective07.OnObj07Update -= ObjectiveUpdateAnimation;
        Objective07.OnObj07Complete -= ObjectiveCompleteAnimation;
        Objective08.OnObj08Update -= ObjectiveUpdateAnimation;
        Objective08.OnObj08Complete -= ObjectiveCompleteAnimation;
        Objective09.OnObj09Update -= ObjectiveUpdateAnimation;
        Objective09.OnObj09Complete -= ObjectiveCompleteAnimation;
        Objective10.OnObj10Update -= ObjectiveUpdateAnimation;
        Objective10.OnObj10Complete -= ObjectiveCompleteAnimation;
        Objective11.OnObj11Update -= ObjectiveUpdateAnimation;
        Objective11.OnObj11Complete -= ObjectiveCompleteAnimation;
        Objective12.OnObj12Update -= ObjectiveUpdateAnimation;
        Objective12.OnObj12Complete -= ObjectiveCompleteAnimation;
        Objective13.OnObj13Update -= ObjectiveUpdateAnimation;
        Objective13.OnObj13Complete -= ObjectiveCompleteAnimation;
        Objective14.OnObj14Update -= ObjectiveUpdateAnimation;
        Objective14.OnObj14Complete -= ObjectiveCompleteAnimation;
        Objective15.OnObj15Update -= ObjectiveUpdateAnimation;
        Objective15.OnObj15Complete -= ObjectiveCompleteAnimation;
        Objective16.OnObj16Update -= ObjectiveUpdateAnimation;
        Objective16.OnObj16Complete -= ObjectiveCompleteAnimation;
        Objective17.OnObj17Update -= ObjectiveUpdateAnimation;
        Objective17.OnObj17Complete -= ObjectiveCompleteAnimation;
        Objective18.OnObj18Update -= ObjectiveUpdateAnimation;
        Objective18.OnObj18Complete -= ObjectiveCompleteAnimation;
        Objective19.OnObj19Update -= ObjectiveUpdateAnimation;
        Objective19.OnObj19Complete -= ObjectiveCompleteAnimation;
        Objective20.OnObj20Update -= ObjectiveUpdateAnimation;
        Objective20.OnObj20Complete -= ObjectiveCompleteAnimation;
        Objective21.OnObj21Update -= ObjectiveUpdateAnimation;
        Objective21.OnObj21Complete -= ObjectiveCompleteAnimation;
        Objective22.OnObj22Update -= ObjectiveUpdateAnimation;
        Objective22.OnObj22Complete -= ObjectiveCompleteAnimation;
        Objective23.OnObj23Update -= ObjectiveUpdateAnimation;
        Objective23.OnObj23Complete -= ObjectiveCompleteAnimation;
        Objective24.OnObj24Update -= ObjectiveUpdateAnimation;
        Objective24.OnObj24Complete -= ObjectiveCompleteAnimation;
        Objective25.OnObj25Update -= ObjectiveUpdateAnimation;
        Objective25.OnObj25Complete -= ObjectiveCompleteAnimation;
        Objecitive26.OnObj26Update -= ObjectiveUpdateAnimation;
        Objecitive26.OnObj26Complete -= ObjectiveCompleteAnimation;
        Objective27.OnObj27Update -= ObjectiveUpdateAnimation;
        Objective27.OnObj27Complete -= ObjectiveCompleteAnimation;
        Objective28.OnObj28Update -= ObjectiveUpdateAnimation;
        Objective28.OnObj28Complete -= ObjectiveCompleteAnimation;

    }

}
