using UnityEngine;
using TMPro;

// this class is singleton ...i.e it can be accessed from anywhere
public class InteractiveItemTextUI : MonoBehaviour
{
    public static InteractiveItemTextUI Instance { get; private set; }

    [SerializeField] TextMeshProUGUI itemText;

    [SerializeField] Transform[] intractImageAndText;

    bool isPlayerIntracting;
    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Player.OnIntract += Player_OnIntract;
    }

    private void Player_OnIntract(object sender, Player.OnIntractEventArgs e)
    {
        isPlayerIntracting = e.intracting;
        ShowVisuals();
    }

    public void SetItemTextFromSO(IntractiblesSO intractiblesSO)
    {
        itemText.text = intractiblesSO.prefabName;
    }

    public void SetItemText(string text)
    {
        itemText.text = text;
    }

    void ShowVisuals()
    {
        foreach (Transform item in intractImageAndText)
        {
            item.gameObject.SetActive(isPlayerIntracting);
        }
    }

   
}
