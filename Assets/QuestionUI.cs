using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class QuestionUI : MonoBehaviour
{
    public static QuestionUI instance;

    public Button EditBtn;

    public Image itemIcon;
    public TMP_Text itemName;
    private TMP_Text itemDesc;
    public TMP_Text itemPrice;
    public TMP_InputField itemAmount;
    public TMP_Text totalPrice;

    ItemSO selectedItem;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {

        this.EditBtn.onClick.AddListener(SetupManager.Instance.OpenMainPanel);
    }
}