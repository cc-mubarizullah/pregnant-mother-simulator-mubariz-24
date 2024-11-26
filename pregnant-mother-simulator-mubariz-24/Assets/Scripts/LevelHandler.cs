using UnityEngine;

public class LevelHandler : MonoBehaviour //this script is attached with gameobject that is present in GAMEPLAY scene
{
    // this script will listen to data that LevelDataHolder will give and activate the corresponding level gameobject

    [SerializeField] GameObject[] allLevels;
    LevelDataHolder levelDataHolder;
    private void Start()
    {
        levelDataHolder = FindAnyObjectByType<LevelDataHolder>();
    }
    private void Update()
    {
        foreach (GameObject level in allLevels)
        {
            if (level.name == levelDataHolder.LevelName)
            {
                level.SetActive(true);
                Debug.Log(levelDataHolder.LevelName);
            }
        }
    }
}
