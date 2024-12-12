using UnityEngine;

public class SFXmanager : MonoBehaviour
{
    public AudioClip doorOpenSFX;
    public AudioClip doorCloseSFX;
    public AudioClip drawerOpenSFX;
    public AudioClip drawerCloseSFX;
    public AudioClip objectiveUpdateSFX;
    public AudioClip objectiveCompleteSFX;
    public AudioClip waterPouringSFX;
    public AudioClip waterDrinkSFX;
    public AudioClip hintSFX;
    public AudioClip swallowFood1;
    public AudioClip swallowFood2;


    public static SFXmanager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null)
            Debug.LogWarning("There are more than one instances of VFX manger class");
        Instance = this;
    }

    AudioSource m_AudioSource;


    public void PlaySoundEffectOnPosition(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
    public void PlayRandomSoundEffectOnPosition(AudioClip audioClip1, AudioClip audioClip2, Vector3 position, float volume = 1f)
    {
        AudioClip randomAudio = Random.Range(0, 2) == 0 ? audioClip1 : audioClip2; 
        AudioSource.PlayClipAtPoint(randomAudio, position, volume);
    }
}
