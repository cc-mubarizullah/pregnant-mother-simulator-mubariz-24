using UnityEngine;

public class LevelDataHolder : MonoBehaviour
{
    [SerializeField] LevelSelection levelSelection;
    public static LevelDataHolder Instance;
    [HideInInspector]
    public string LevelName;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        levelSelection.OnLevelSelected += LevelSelection_OnLevelSelected;
    }

    private void LevelSelection_OnLevelSelected(object sender, LevelSelection.OnLevelSelectedEventArgs e)
    {
        LevelName = e.levelName;
    }
}
