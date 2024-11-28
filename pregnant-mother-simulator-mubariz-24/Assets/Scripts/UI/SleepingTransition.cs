using UnityEngine;
using UnityEngine.UI;

public class SleepingTransition : MonoBehaviour
{
    [SerializeField] Image imageForSleepingTransition;
    float alphaValue;
    float initialValue = 0f;
    float finalValue = 0.8f;
    float elapsedtime;
    [SerializeField] float timeToAnimate = 5f;

    private void Start()
    {
        initialValue = 0f;
    }
    private void Update()
    {
        Color color = imageForSleepingTransition.color;
        color.a = alphaValue;
        imageForSleepingTransition.color = color;
        LerpingAlpha();
    }

    void LerpingAlpha()
    {
        elapsedtime += Time.deltaTime;
        float t = elapsedtime / timeToAnimate;
        alphaValue = Mathf.Lerp(initialValue, finalValue, t);
    }

}
