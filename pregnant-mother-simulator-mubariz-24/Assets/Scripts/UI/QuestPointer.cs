using UnityEngine;
using UnityEngine.UI;

public class QuestPointer : MonoBehaviour
{
    [SerializeField] Image questImage;
    Transform targetTransform;

   
    private void Update()
    {
        if (targetTransform != null)
        {
            questImage.gameObject.SetActive(true);
            float minX = questImage.GetPixelAdjustedRect().width / 2;
            float maxX = Screen.width - minX;


            float minY = questImage.GetPixelAdjustedRect().height / 2;
            float maxY = Screen.height - minY;

            Vector2 pos = Camera.main.WorldToScreenPoint(targetTransform.position);

            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            questImage.transform.position = pos;
        }
    }
    public void SetQuestTransform(Transform transformOfGameOBject)
    {
        targetTransform = transformOfGameOBject;
    }
}
