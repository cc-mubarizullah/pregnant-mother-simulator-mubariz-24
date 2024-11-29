using System;
using UnityEngine;

public class Objective9Trigger : MonoBehaviour
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
