using UnityEngine;

public class LevelUnlocker : MonoBehaviour
{
    [SerializeField] GameObject level02Unlocker;
    [SerializeField] GameObject level03Unlocker;
    [SerializeField] GameObject level04Unlocker;
    [SerializeField] GameObject level05Unlocker;

    
    private void Update()
    {
        level02Unlocker.SetActive(PlayerPrefs.GetInt("Level02Unlock") ==10);  // if the value has been set to 0 only than the condition becomes true
        level03Unlocker.SetActive(PlayerPrefs.GetInt("Level03Unlock") ==10);
        level04Unlocker.SetActive(PlayerPrefs.GetInt("Level04Unlock") ==10);
        level05Unlocker.SetActive(PlayerPrefs.GetInt("Level05Unlock") ==10);
    }
}
