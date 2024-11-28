using UnityEngine;
using TMPro;

public class HintUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hintTextUI;
   
    public void ShowHintText(string textToShow)
    {
        hintTextUI.text = textToShow;
    }
}
