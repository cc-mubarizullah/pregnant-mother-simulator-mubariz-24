using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;

    public IEnumerator LoadSceneASync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        
        while (!operation.isDone)
        {
            loadingScreen.SetActive(true);
            yield return null;
        }
        loadingScreen.SetActive(false);
    }
}
