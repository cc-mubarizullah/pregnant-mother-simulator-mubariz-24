using UnityEngine;
using UnityEngine.UI;

public class HintUI : MonoBehaviour
{
    [SerializeField] Text hintTextUI;
   
    public void ShowHintText(string textToShow)
    {
        hintTextUI.text = textToShow;
    }
}
