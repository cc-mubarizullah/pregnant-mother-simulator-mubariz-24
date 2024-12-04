using UnityEngine;
using UnityEngine.Events;

public class Level01 : MonoBehaviour
{
    [SerializeField] Transform playerPositionInLevel1;
    public GameObject[] objOfLevel1;

    [Tooltip("Enable or disable gameobject according to the last level")]
    public UnityEvent ProgressFromLastLevel;

    private void OnEnable()
    {
        ProgressFromLastLevel?.Invoke();
    }
    private void Start()
    {
        foreach (GameObject obj in objOfLevel1)
        {
            obj.SetActive(false);
        }
        objOfLevel1[0].SetActive(true);
        Player.Instance.transform.position = playerPositionInLevel1.position;
    }
}
