using UnityEngine;
using UnityEngine.Events;

public class Level04 : MonoBehaviour
{
    [SerializeField] Transform playerPositionInLevel4;
    [SerializeField] GameObject level04upstairCutscene;
    [SerializeField] GameObject[] upstairLock;

    public GameObject[] objOfLevel4;

    [Tooltip("Enable or disable gameobject according to the last level")]
    public UnityEvent ProgressFromLastLevel;

    private void OnEnable()
    {
        ProgressFromLastLevel?.Invoke();
    }
    private void Start()
    {
        foreach (GameObject collider in upstairLock)
        {
            collider.SetActive(false);
        }
        level04upstairCutscene.SetActive(true);
        Player.Instance.transform.position = playerPositionInLevel4.position;
        foreach (GameObject obj in objOfLevel4)
        {
            obj.SetActive(false);
        }
        objOfLevel4[0].SetActive(true);
    }

}
