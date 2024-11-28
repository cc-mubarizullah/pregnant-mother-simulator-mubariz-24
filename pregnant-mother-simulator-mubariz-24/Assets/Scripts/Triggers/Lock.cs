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
                SFXmanager.Instance.PlaySoundEffectOnPosition(SFXmanager.Instance.errorSFX, Player.Instance.transform.position);
                hintUI.ShowHintText("Play More to Unlock");
                hasTriggeredAlready = true;
            }
        }
        
    }

}
