using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    enum LockOrUnlock
    {
        Yes,
        No
    }

    [SerializeField] LockOrUnlock lockUpstairOrNot;

    [SerializeField] Transform playerPositionInLevel;
    [SerializeField] GameObject[] upstairLock;

    public GameObject[] objOfThisLevel;

    [Tooltip("Enable or disable gameobject according to the last level")]
    public UnityEvent ProgressFromLastLevel;

    bool toLock;

    private void OnEnable()
    {
        ProgressFromLastLevel?.Invoke();
    }

    private void Start()
    {
        switch (lockUpstairOrNot)
        {
            case LockOrUnlock.Yes:
                toLock = true;
                break;
            case LockOrUnlock.No:
                toLock = false;
                break;
            default:
                break;
        }
        foreach (GameObject collider in upstairLock)
        {
            collider.SetActive(toLock);
        }
        Player.Instance.transform.position = playerPositionInLevel.position;
        foreach (GameObject obj in objOfThisLevel)
        {
            obj.SetActive(false);
        }
        objOfThisLevel[0].SetActive(true);

        switch (lockUpstairOrNot)
        {
            case LockOrUnlock.Yes:
                toLock = true;
                break;
            case LockOrUnlock.No:
                toLock = false;
                break;
            default:
                break;
        }
    }

}
