using UnityEngine;
using UnityEngine.Events;

public class Level05 : MonoBehaviour
{
    

    [SerializeField] Transform playerPositionInLevel5;
    [SerializeField] GameObject[] upstairLock;

    public GameObject[] objOfLevel5;

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
        Player.Instance.transform.position = playerPositionInLevel5.position;
        foreach (GameObject obj in objOfLevel5)
        {
            obj.SetActive(false);
        }
        objOfLevel5[0].SetActive(true);
    }
    
}
