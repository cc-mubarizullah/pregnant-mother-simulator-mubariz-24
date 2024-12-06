using UnityEngine;

public class LevelUnlocker : MonoBehaviour
{
    [SerializeField] GameObject level02Unlocker;
    [SerializeField] GameObject level03Unlocker;
    [SerializeField] GameObject level04Unlocker;
    [SerializeField] GameObject level05Unlocker;
    [SerializeField] GameObject level06Unlocker;

    
    private void Update()
    {
        level02Unlocker.SetActive(PlayerPrefs.GetInt("Level02Unlock") !=10);  
        level03Unlocker.SetActive(PlayerPrefs.GetInt("Level03Unlock") !=10);
        level04Unlocker.SetActive(PlayerPrefs.GetInt("Level04Unlock") !=10);
        level05Unlocker.SetActive(PlayerPrefs.GetInt("Level05Unlock") !=10);
        level06Unlocker.SetActive(PlayerPrefs.GetInt("Level06Unlock") !=10);
    }
}
