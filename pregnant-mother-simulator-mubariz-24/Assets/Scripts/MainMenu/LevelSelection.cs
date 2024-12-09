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
        Player.inHome = true; 
    }
    public void Level02()
    {
        SelectLevel("Level02");
        Player.inHome = true;
    }
    public void Level03()
    {
        SelectLevel("Level03");
        Player.inHome = false;
    }
    public void Level04()
    {
        SelectLevel("Level04");
        Player.inHome = true;
    }
    public void Level05()
    {
        SelectLevel("Level05");
        Player.inHome = true;
    }
    public void Level06()
    {
        SelectLevel("Level06");
        Player.inHome = true;
    }

    private void SelectLevel(string levelName)
    {
       LEVELNAME = levelName;
       StartCoroutine( loadingScreenManager.LoadSceneASync("GamePlay"));
    }
}
