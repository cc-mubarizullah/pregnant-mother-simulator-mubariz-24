using UnityEngine;

public class LevelUnlocker : MonoBehaviour
{
    [SerializeField] GameObject level02Unlocker;
    [SerializeField] GameObject level03Unlocker;

    private void Start()
    {
        int level2status = PlayerPrefs.GetInt("Level02Unlock");
        int level3status = PlayerPrefs.GetInt("Level03Unlock");
        Debug.Log(level2status);
        Debug.Log(level3status);
    }
    private void Update()
    {
        level02Unlocker.SetActive(PlayerPrefs.GetInt("Level02Unlock")!=10);  // if the value has been set to 0 only than the condition becomes true
        level03Unlocker.SetActive(PlayerPrefs.GetInt("Level03Unlock")!=10);
    }
}
