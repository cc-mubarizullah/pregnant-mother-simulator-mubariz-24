using UnityEngine;

public class Lock : MonoBehaviour
{
    [SerializeField] HintUI hintUI;
    bool hasTriggeredAlready;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggeredAlready)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                hintUI.gameObject.SetActive(true);
                hintUI.ShowHintText("Play More to Unlock");
                hasTriggeredAlready = true;
            }
        }
        
    }

}
