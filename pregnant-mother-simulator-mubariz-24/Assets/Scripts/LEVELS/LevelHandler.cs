using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    private string levelName;
    [SerializeField] GameObject[] allLevels;
    [SerializeField] GameObject levelCompletePanel;
    int currentLevelIndex = 0;

    private void Start()
    {

    }
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

    public void NextLevel()
    {
        if (currentLevelIndex < allLevels.Length)
        {
            currentLevelIndex++;
            UpdateLevelVisibilty();
        }
        levelCompletePanel.SetActive(false); 
    }

    void UpdateLevelVisibilty()
    {
        for (int i = 0; i < allLevels.Length; i++)
        {
            allLevels[i].SetActive(i==currentLevelIndex);
        }
    }
}
