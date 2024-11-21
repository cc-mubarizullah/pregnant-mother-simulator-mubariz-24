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
        if (canAnimate)
        {
            ForwardAnimation();
        }
        else
        {
            BackwardAnimation();
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
            UIStayOnScreen();
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
            gameObject.SetActive(false);
        }
    }

   

    private void UIStayOnScreen()
    {
        timerClock += Time.deltaTime;
        if (timerClock >= maxTimeUiStaysOnScreen)
        {
            canAnimate = true;
        }
        canAnimate = false;
    }

}
