using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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


}
