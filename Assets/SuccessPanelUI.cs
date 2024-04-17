using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SuccessPanelUI : MonoBehaviour
{
    public static SuccessPanelUI Instance;

    Task task;

    ItemSO Item;
    public Image itemIcon;
    public TMP_Text itemInfo;
    public TMP_Text headerText;

    public TMP_Text poin;
    public Button NextBtn;
    public Button TaskBtn;

    public void Awake()
    {
        Instance = this;
        gameObject.transform.localScale = Vector2.zero;
    }
    public void Start()
    {
        GameUITween.Instance.InstantiateOverlay();
        headerText.text = "Selamat! " + PhotonNetwork.LocalPlayer.NickName;
        TaskBtn.onClick.AddListener(OpenTask);
        NextBtn.onClick.AddListener(GameUITween.Instance.CloseSuccessPanel);

    }

    public void SetItem(Task task)
    {
        Item = task.product;
        itemIcon.sprite = task.product.sprite;
        itemInfo.text = task.amount + " " + task.product.name;
    }

    public void OpenTask()
    {
        GameUITween.Instance.CloseSuccessPanel();
        GameUITween.Instance.OpenTaskPanel();
    }

}
