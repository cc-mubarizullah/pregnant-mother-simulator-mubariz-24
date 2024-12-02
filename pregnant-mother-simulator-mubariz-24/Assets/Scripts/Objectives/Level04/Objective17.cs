using UnityEngine;
using UnityEngine.Events;
using System;

public class Objective17 : MonoBehaviour
{
    [SerializeField] ObjectivesSO seventeethObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;

    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    public static event EventHandler OnObj17Update;
    public static event EventHandler OnObj17Complete;

    float clock;
    float clock2;

    private void OnEnable()
    {
        eventsToCallWhenEnable?.Invoke();
    }
    private void OnDisable()
    {
        eventsToCallWhenDisable?.Invoke();
    }

}
