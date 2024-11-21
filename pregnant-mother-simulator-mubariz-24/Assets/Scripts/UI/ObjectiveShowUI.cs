using UnityEngine;
using TMPro;
public class ObjectiveShowUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI objectiveTextUI;
    [Tooltip("This transform will hold the child of gameobject which holds the whole objective UI. In this the gameobject named emptyParent.")]
    [SerializeField] Transform child;

    public void ShowObjectiveUI()
    {
        child.gameObject.SetActive(true);
    }
    public void HideObjectiveUI()
    {
        child.gameObject.SetActive(true);
    }
    public void ShowObjectiveText(string objectiveToShow)
    {
        objectiveTextUI.text = objectiveToShow;
    }
}
