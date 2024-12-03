using UnityEngine;
using UnityEngine.Events;
using System;

public class Objective16 : MonoBehaviour
{
    [SerializeField] ObjectivesSO sixteenthObjectiveSO;
    [SerializeField] ObjectiveShowUI objectiveShowUI;
    [SerializeField] GameObject blackBabyPhoto;
    ObjectDrop[] objectDrop;
    [Tooltip("Gameobject whose layers to change after objective complete")]
    [SerializeField] GameObject[] photoHanged;

    public UnityEvent eventsToCallWhenEnable;
    public UnityEvent eventsToCallWhenDisable;

    public static event EventHandler OnObj16Update;
    public static event EventHandler OnObj16Complete;

    float clock;
    float clock2;

    int photosHanged;
    int totalPhotosToHang = 2;
    bool targetCompleted;
    private void OnEnable()
    {
        eventsToCallWhenEnable?.Invoke();
    }
    private void Start()
    {
        objectDrop = FindObjectsByType<ObjectDrop>(FindObjectsInactive.Include,FindObjectsSortMode.None);
        foreach (ObjectDrop p in objectDrop)
        {
            p.OnPhotoHanged += P_OnPhotoHanged;
        }

        blackBabyPhoto.layer = 7;
    }

    private void P_OnPhotoHanged()
    {
        if (photosHanged < totalPhotosToHang)
        {
            photosHanged++;
        }
        if (photosHanged == totalPhotosToHang)
        {
            targetCompleted = true;
        }
    }


    private void Update()
    {
        DelayAfterActivation();
        objectiveShowUI.ShowObjectiveText(sixteenthObjectiveSO.objectivesText);
        CheckProgress();
    }

    void CheckProgress()
    {
        if (targetCompleted)
        {
            if (DelayAfterObjComplete())
            {
                {
                    //OBJECTIVE COMPLETE
                    OnObj16Complete?.Invoke(this, EventArgs.Empty);
                    foreach (GameObject obj in photoHanged)
                    {
                        { obj.layer = 0; }
                    }
                    Destroy(gameObject, 0.5f);
                    
                }
            }
        }
    }
    bool DelayAfterObjComplete()
    {
        clock2 += Time.deltaTime;
        if (clock2 >= 2f)
        {
            return true;
        }
        return false;
    }

    void DelayAfterActivation()     // this function will fire event that objective ui will listen and show objective animation
    {
        clock += Time.deltaTime;
        if (clock > 2f && clock < 2.1f)
        {
            OnObj16Update?.Invoke(this, EventArgs.Empty);
        }
    }


    private void OnDisable()
    {
        eventsToCallWhenDisable?.Invoke();
    }

}
