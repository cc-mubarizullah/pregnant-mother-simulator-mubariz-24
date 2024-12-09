using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject levelSelectionPanel;
    [SerializeField] GameObject mainMenuPanel;
    public void Play()
    {
        levelSelectionPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }
}
