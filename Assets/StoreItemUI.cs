using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemUI : MonoBehaviour
{
    public static StoreItemUI Instance;
    public Image itemIcon;
    public int cost;
    public TMP_Text itemName;
    public string itemDesc;

    public Button itemButton;

    public void Awake()
    {
        Instance = this;
    }
}
