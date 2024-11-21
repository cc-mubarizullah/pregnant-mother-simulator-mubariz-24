using UnityEngine;

public class Animation_Generic_UI : MonoBehaviour
{
    float timerClock;
    float maxTimeUiStaysOnScreen = 5f;


    bool canAnimate;
    Vector3 initialPosition;
    Vector3 targetPosition;
    [SerializeField] float targetPositionValue;
   
    float elapsedTime;
    [SerializeField] float maxTimerForAnimation = 5;

    enum AxisToChange
    {
        XAxis,
        YAxis
    }
    [SerializeField] AxisToChange axisToChange;


    private void OnEnable()
    {
        canAnimate = true;
    }
    private void Start()
    {
        initialPosition = transform.position;
        targetPosition = transform.position;
        switch (axisToChange)
        {
            case AxisToChange.XAxis:
                targetPosition.x = transform.position.x - targetPositionValue;
                break;
            case AxisToChange.YAxis:
                targetPosition.y = transform.position.y - targetPositionValue;
                break;
        }
    }

    private void Update()
    {
        timerClock += Time.deltaTime;
        if (timerClock >= maxTimeUiStaysOnScreen)
        {
            canAnimate = false;
            BackwardAnimation();
        }
        if (canAnimate)
        {
            ForwardAnimation();
        }
        
    }

    void ForwardAnimation()
    {
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / maxTimerForAnimation;
        transform.position = Vector2.Lerp(transform.position, targetPosition, t);
        if (transform.position == targetPosition)
        {
            elapsedTime = 0f;
            canAnimate = false;
        }
    }

    void BackwardAnimation()
    {
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / maxTimerForAnimation;
        transform.position = Vector2.Lerp(transform.position, initialPosition, t);

        if (transform.position == initialPosition)
        {
            elapsedTime = 0f;
            timerClock = 0f;
            canAnimate = true;
            gameObject.SetActive(false);
        }
    }

   

    //private void UIStayOnScreen()
    //{
    //    timerClock += Time.deltaTime;
    //    if (timerClock >= maxTimeUiStaysOnScreen)
    //    {
    //        canAnimate = true;
    //        timerClock =0f;
    //    }
    //    canAnimate = false;
    //}

}
