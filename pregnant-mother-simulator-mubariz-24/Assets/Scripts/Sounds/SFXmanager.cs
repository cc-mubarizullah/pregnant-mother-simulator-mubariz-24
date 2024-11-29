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
    public AudioClip errorSFX;
    public AudioClip waterDrinkSFX;
    public AudioClip hintSFX;


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
}
