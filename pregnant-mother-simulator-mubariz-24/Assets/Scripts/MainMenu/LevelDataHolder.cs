using UnityEngine;

public class LevelDataHolder : MonoBehaviour
{

    /// <summary>
    /// This script will be used to store the data that which level player has selected
    // and than that data will be used by the script in gameplay to activate the corresponding level gameobject having relative objectives
    /// </summary>
    [SerializeField] LevelSelection levelSelection;  // ref of the class that will tell us the string of level e.g "LEVEL"
    public static LevelDataHolder Instance;  // we are making this class static
    //    [HideInInspector]
    public string LevelName; //this is the member of the class that will share the name of the level that will then iterate between all Levels names
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //don't destroy this gameobject when scene change
        }
        else
        {
            Destroy(gameObject); // if there is any other instance of the class then destroy this gameobject
        }
    }
    private void Start()
    {
        levelSelection.OnLevelSelected += LevelSelection_OnLevelSelected;   // we subscribe to the event when player select level and send data along
    }

    private void LevelSelection_OnLevelSelected(object sender, LevelSelection.OnLevelSelectedEventArgs e)
    {
        LevelName = e.levelName;     // we assign that string to our string varible
    }
}
