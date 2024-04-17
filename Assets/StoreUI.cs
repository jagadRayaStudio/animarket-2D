using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreUI : MonoBehaviour
{
    public GameObject ItemParent;
    public GameObject ItemPrefab;
    public TMP_Text storeName;
    public Button closePanelBtn;

    public static StoreUI Instance;

    private void Awake()
    {
        Instance = this;
    }


}
