using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Image imageToFill;

    public IEnumerator LoadSceneASync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            Debug.Log("the progress of loading in progress.operation is" + operation.progress);
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            imageToFill.fillAmount = progress;
            yield return null;
        }
        loadingScreen.SetActive(false);
    }
}
