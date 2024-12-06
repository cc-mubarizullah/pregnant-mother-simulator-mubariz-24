using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private LoadingScreenManager loadingScreenManager;

    public static string LEVELNAME;
    public void Level01()
    {
        SelectLevel("Level01");
    }
    public void Level02()
    {
        SelectLevel("Level02");
    }
    public void Level03()
    {
        SelectLevel("Level03");
    }
    public void Level04()
    {
        SelectLevel("Level04");
    }
    public void Level05()
    {
        SelectLevel("Level05");
    }
    public void Level06()
    {
        SelectLevel("Level06");
    }

    private void SelectLevel(string levelName)
    {
       LEVELNAME = levelName;
       StartCoroutine( loadingScreenManager.LoadSceneASync("GamePlay"));
    }
}
