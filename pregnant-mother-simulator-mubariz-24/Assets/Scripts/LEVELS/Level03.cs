using UnityEngine;

public class Level03 : MonoBehaviour
{
    [SerializeField] GameObject reportOnPlayerHand;
    [SerializeField] Transform playerPositionInLevel3;

    public GameObject[] objOfLevel3;
    private void Start()
    {
        reportOnPlayerHand.SetActive(true);
        Player.Instance.transform.position = playerPositionInLevel3.position;
        foreach (GameObject obj in objOfLevel3)
        {
            obj.SetActive(false);
        }
        objOfLevel3[0].SetActive(true);
    }


}
