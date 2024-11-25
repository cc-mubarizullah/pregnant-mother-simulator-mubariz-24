using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] LoadingScreenManager loadingScreenManager;
    public void Level01()
    {
        loadingScreenManager.LoadScene("GamePlay");
    }
}
