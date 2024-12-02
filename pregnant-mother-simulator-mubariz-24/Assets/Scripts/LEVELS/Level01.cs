using UnityEngine;

public class Level01 : MonoBehaviour
{
    public GameObject[] objOfLevel1;
    private void Start()
    {
        foreach (GameObject obj in objOfLevel1)
        {
            obj.SetActive(false);
        }
        objOfLevel1[0].SetActive(true);
    }
}
