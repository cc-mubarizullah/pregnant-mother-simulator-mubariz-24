using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    private string levelName;
    [SerializeField] GameObject[] allLevels;

    private void OnEnable()
    {
        levelName = LevelSelection.LEVELNAME;
        foreach (GameObject level in allLevels)
        {
           level.SetActive(false);
        }
    }

    private void Update()
    {
        foreach (GameObject level in allLevels)
        {
            if (level.name == levelName)
            {
                level.SetActive(true);
            }
        }
    }
}
