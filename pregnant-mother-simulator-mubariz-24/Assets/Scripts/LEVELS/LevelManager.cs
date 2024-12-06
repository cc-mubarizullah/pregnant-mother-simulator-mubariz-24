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
    [SerializeField] GameObject player;
    [SerializeField] Transform playerPositionInLevel;
    [SerializeField] GameObject[] upstairLock;

    public GameObject firstObjOfThisLevel;

    [Tooltip("Enable or disable gameobject according to the last level")]
    public UnityEvent ProgressFromLastLevel;

    bool toLock;

    private void OnEnable()
    {
        ProgressFromLastLevel?.Invoke();
        // SETTING PLAYER POSITION ACCORDING TO THE LEVEL

        player.transform.position = playerPositionInLevel.transform.position;
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
        }

        // CHECKING ENUM STATE ON THE BASIS OF WHICH UPSTAIRS WILL BE LOCKED OR UNLOCKED
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

        //SETTING ACTIVATION OF COLLIDER AND TRIGGER
        foreach (GameObject collider in upstairLock)
        {
            collider.SetActive(toLock);
        }



        //ACTIVATING THE FIRST ONE
        firstObjOfThisLevel.SetActive(true);


    }

}
