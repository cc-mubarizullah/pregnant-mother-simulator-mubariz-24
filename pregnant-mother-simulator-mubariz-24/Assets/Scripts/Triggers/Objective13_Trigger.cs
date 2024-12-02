using UnityEngine;
using System;

public class Objective13_Trigger : MonoBehaviour
{
    public event Action OnPlayerTriggDocTable;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerTriggDocTable?.Invoke();
        }
    }
}
