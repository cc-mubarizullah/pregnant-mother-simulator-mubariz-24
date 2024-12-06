using UnityEngine;

public class LevelHandler : MonoBehaviour //this script is attached with gameobject that is present in GAMEPLAY scene
{
    // this script will listen to data that LevelDataHolder will give and activate the corresponding level gameobject after comparing the string with all levels name

    [SerializeField] GameObject[] allLevels;
    LevelDataHolder levelDataHolder;
    private void Start()
    {
        levelDataHolder = FindAnyObjectByType<LevelDataHolder>();    // made a variable ....this field can be null if we didn't start from mainmenu


        //foreach (GameObject level in allLevels)        // iterates through all levels in the array and disable all
        //{
        //    level.SetActive(false);
        //}
    }
    private void Update()
    {
        foreach (GameObject level in allLevels)        // iterates through all levels in the array
        {
            if (levelDataHolder != null)
            {
                if (level.name == levelDataHolder.LevelName)        //checks if any Level gameobject has the same name as the string
                {
                    level.SetActive(true);                        // if found activate that gameobject
                }
            }
        }

    }
}
