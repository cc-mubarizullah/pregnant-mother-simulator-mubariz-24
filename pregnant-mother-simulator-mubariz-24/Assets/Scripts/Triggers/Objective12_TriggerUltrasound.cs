using UnityEngine;
using System;

public class Objective12_TriggerUltrasound : MonoBehaviour
{
    public event Action OnPlayerTriggerUltraSoundMachine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerTriggerUltraSoundMachine?.Invoke();
        }
    }
}
