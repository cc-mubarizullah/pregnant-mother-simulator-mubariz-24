using UnityEngine;

public class Level04 : MonoBehaviour
{
    [SerializeField] Transform playerPositionInLevel3;
    [SerializeField] GameObject level04upstairCutscene;
    [SerializeField] GameObject[] upstairLock;

    public GameObject[] objOfLevel4;
    private void Start()
    {
        foreach (GameObject collider in upstairLock)
        {
            collider.SetActive(false);
        }
        level04upstairCutscene.SetActive(true);
        Player.Instance.transform.position = playerPositionInLevel3.position;
        foreach (GameObject obj in objOfLevel4)
        {
            obj.SetActive(false);
        }
        objOfLevel4[0].SetActive(true);
    }

}
