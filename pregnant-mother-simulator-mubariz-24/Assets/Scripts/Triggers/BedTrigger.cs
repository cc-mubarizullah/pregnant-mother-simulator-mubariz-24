using System;
using UnityEngine;

public class BedTrigger : MonoBehaviour
{
    public event Action OnPlayerTriggerBed;
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Player"))
       {
           OnPlayerTriggerBed?.Invoke();
       }
    }
}
