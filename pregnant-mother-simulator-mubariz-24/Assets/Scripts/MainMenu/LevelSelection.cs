using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    const string LEVEL01 = "Level01";
    const string LEVEL02 = "Level02";
    const string LEVEL03 = "Level03";

    [SerializeField] LoadingScreenManager loadingScreenManager;
    public event EventHandler<OnLevelSelectedEventArgs> OnLevelSelected;
    public class OnLevelSelectedEventArgs : EventArgs
    {
        public string levelName;
    }
    public void Level01()
    {
        StartCoroutine(loadingScreenManager.LoadSceneASync("GamePlay"));
        OnLevelSelected?.Invoke(this, new OnLevelSelectedEventArgs()
        {
            levelName = LEVEL01
        });
    }
    public void Level02()
    {
        StartCoroutine(loadingScreenManager.LoadSceneASync("GamePlay"));
        OnLevelSelected?.Invoke(this, new OnLevelSelectedEventArgs()
        {
            levelName = LEVEL02
        });
    }
    public void Level03()
    {
        StartCoroutine(loadingScreenManager.LoadSceneASync("GamePlay"));
        OnLevelSelected?.Invoke(this, new OnLevelSelectedEventArgs()
        {
            levelName = LEVEL03
        });
    }
}
