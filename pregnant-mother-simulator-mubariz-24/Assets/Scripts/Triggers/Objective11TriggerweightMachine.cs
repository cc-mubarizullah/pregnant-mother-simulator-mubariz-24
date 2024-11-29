using UnityEngine;
using System;

public class Objective11TriggerweightMachine : MonoBehaviour
{
    float clock;
    float timeToStayInTrigger = 5f;

    public event Action OnPlayerTriggWeightmachine;
    public event Action OnPlayerStayedEnoughInTriggerArea;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerTriggWeightmachine?.Invoke();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            clock += Time.deltaTime;
            if (clock > timeToStayInTrigger)
            {
                OnPlayerStayedEnoughInTriggerArea?.Invoke();
            }
        }
    }
}
