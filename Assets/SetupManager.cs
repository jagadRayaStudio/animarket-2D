using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SetupManager : MonoBehaviour
{
    public static SetupManager Instance;

    ItemSO selectedItem;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenMainPanel()
    {
        QuestionMakerUI.instance.mainPanel.SetActive(true);
        QuestionMakerUI.instance.storeList.gameObject.SetActive(true);
        QuestionMakerUI.instance.BackButton2.onClick.AddListener(() => QuestionMakerUI.instance.mainPanel.SetActive(false));
    }

    public void UpdateQuestion(ItemSO selectedItem)
    {
        this.selectedItem = selectedItem;

        SetSelectedItem(selectedItem);

        QuestionMakerUI.instance.mainPanel.gameObject.SetActive(false);
        QuestionMakerUI.instance.itemList.gameObject.SetActive(false);
    }

    public void SetSelectedItem(ItemSO item)
    {
        selectedItem = item;
        QuestionUI.instance.itemIcon.sprite = selectedItem.sprite;
        QuestionUI.instance.itemName.text = selectedItem.itemName;
        QuestionUI.instance.itemPrice.text = selectedItem.cost.ToString();

        QuestionData.Instance.itemName = selectedItem.itemName;
        QuestionData.Instance.icon = selectedItem.sprite;
        QuestionData.Instance.cost = selectedItem.cost;


        QuestionUI.instance.itemAmount.onValueChanged.AddListener(delegate { UpdateTotalPrice(); });
    }
    public void UpdateTotalPrice()
    {
        if (selectedItem != null)
        {
            int amount = int.Parse(QuestionUI.instance.itemAmount.text);
            int price = selectedItem.cost;
            int total = amount * price;
            QuestionUI.instance.totalPrice.text = total.ToString();

            QuestionData.Instance.amount = int.Parse(QuestionUI.instance.itemAmount.text);
            QuestionData.Instance.grandTotal = total; 
        }
    }

    public void ResetAmount()
    {
        QuestionUI.instance.itemAmount.text = string.Empty;
    }
}
