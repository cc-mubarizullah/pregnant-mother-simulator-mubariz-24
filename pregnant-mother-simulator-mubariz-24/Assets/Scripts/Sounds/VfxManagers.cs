using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VfxManagers : MonoBehaviour
{
  


   public static VfxManagers Instance;
    private void Awake()
    {
        if (Instance != null)
            Debug.LogWarning("There are more than one instances of VFX manger class");
        Instance = this;
    }

  
    public void PlaySoundEffect(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
}
