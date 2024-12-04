using UnityEngine;
using UnityEngine.Events;

public class Level02 : MonoBehaviour
{
    [SerializeField] Transform playerPositionInLevel2;
    public GameObject[] objOfLevel2;

    [Tooltip("Enable or disable gameobject according to the last level")]
    public UnityEvent ProgressFromLastLevel;

    private void OnEnable()
    {
        ProgressFromLastLevel?.Invoke();
    }
    private void Start()
    {
        foreach (GameObject obj in objOfLevel2)
        {
            obj.SetActive(false);
        }
        objOfLevel2[0].SetActive(true);
        Player.Instance.transform.position = playerPositionInLevel2.position;
    }
}
