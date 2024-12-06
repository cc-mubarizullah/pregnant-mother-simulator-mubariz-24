using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = musicSlider.value;
        musicSlider.onValueChanged.AddListener(OnMusicSliderValueChange);
        audioSource.Play();
        
    }
    public void PlaySound()
    {
        audioSource.Play();
    }
    public void PauseSound()
    {
        audioSource.Stop();
    }

    private void OnMusicSliderValueChange(float value)
    {
        audioSource.volume = value;
    }


}
