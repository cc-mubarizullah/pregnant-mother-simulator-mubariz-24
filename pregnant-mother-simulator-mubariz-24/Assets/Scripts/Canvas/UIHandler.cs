using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject musicOnButton;
    [SerializeField] GameObject musicOffButton;
    [SerializeField] GameObject musicManagerGO;
    [SerializeField] GameObject pausePanel;
    bool musicPlaying = false;
    public void SettingButton()
    {
        settingPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void SettingPenelBack()
    {
        settingPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void PausePenelBack()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private void Start()
    {
        musicOffButton.SetActive(false);
        musicOffButton.SetActive(false);

        if (!musicPlaying)
        {
            musicOnButton.SetActive(true);
            musicManagerGO.GetComponentInParent<AudioSource>().Play();
            musicPlaying = true;
        }

    }
    public void MusicButton()
    {
        if (!musicPlaying)
        {
            musicOnButton.SetActive(true);
            musicOffButton.SetActive(false);
            musicManagerGO.GetComponentInParent<AudioSource>().Play();
            musicPlaying = true;
        }
        else
        {
            musicOffButton.SetActive(true);
            musicOnButton.SetActive(false);
            musicManagerGO.GetComponentInParent<AudioSource>().Pause();
            musicPlaying = false;
        }
    }

    public void PauseButton()
    {
        pausePanel.SetActive(true);
        //Time.timeScale = 0f;
    }

    public void ToMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ResumeButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

}
