using UnityEngine;
using UnityEngine.Events;
using System;

public class Objective16 : MonoBehaviour
{
    [SerializeField] ObjectivesSO sixteenthObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;

    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    public static event EventHandler OnObj16Update;
    public static event EventHandler OnObj16Complete;

    float clock;
    float clock2;

    int photosHanged;
    int totalPhotosToHang = 2;

    private void OnEnable()
    {
        eventsToCallWhenEnable?.Invoke();
    }
    private void OnDisable()
    {
        eventsToCallWhenDisable?.Invoke();
    }

}
