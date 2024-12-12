using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    private string levelName;
    [SerializeField] GameObject[] allLevels;
    [SerializeField] GameObject levelCompletePanel;
    [SerializeField] Transform playerPosInHome;
    [SerializeField] Transform playerPosInOffice;
     public static int currentLevelIndex = 0;

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
            if (allLevels[2].activeSelf)
            {
                Player.Instance.transform.position = playerPosInOffice.position;
            }
            else
            {
                Player.Instance.transform.position = playerPosInHome.position;
            }
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
