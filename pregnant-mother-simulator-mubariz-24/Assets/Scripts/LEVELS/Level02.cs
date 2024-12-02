using UnityEngine;

public class Level02 : MonoBehaviour
{
    public GameObject[] objOfLevel2;
    private void Start()
    {
        foreach (GameObject obj in objOfLevel2)
        {
            obj.SetActive(false);
        }
        objOfLevel2[0].SetActive(true);
    }
}
