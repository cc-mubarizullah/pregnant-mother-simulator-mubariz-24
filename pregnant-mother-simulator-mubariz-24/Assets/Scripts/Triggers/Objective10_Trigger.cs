using UnityEngine;
using System;

public class Objective10_Trigger : MonoBehaviour
{
    float clock;
    float timeToStayInTrigger = 5f;

    public event Action OnPlayerTriggBPmachine;
    public event Action OnPlayerStayedEnoughInTriggerArea;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerTriggBPmachine?.Invoke();
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
