using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetupItemUI : MonoBehaviour
{
    public Image itemIcon;
    public TMP_Text itemName;
    public TMP_Text itemDesc;
    public TMP_Text itemPrice;
    public TMP_InputField itemAmount;
    public TMP_Text totalPrice;

    public Button AddQuestionButton;

    private ItemSO selectedItem;

    public QuestionListUI questionListUI;

    public static SetupItemUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void SetSelectedItem(ItemSO item)
    {
        selectedItem = item;
        itemIcon.sprite = selectedItem.sprite;
        itemName.text = selectedItem.itemName;
        itemDesc.text = selectedItem.itemDesc.ToString();
        itemPrice.text = selectedItem.cost.ToString();

        itemAmount.onValueChanged.AddListener(delegate { UpdateTotalPrice(); });

        AddQuestionButton.onClick.AddListener(() => CreateQuestion());
    }

    public void UpdateTotalPrice()
    {
        if (selectedItem != null)
        {
            int amount = int.Parse(itemAmount.text);
            int price = selectedItem.cost;
            int total = amount * price;
            totalPrice.text = total.ToString();
        }
    }

    public void CreateQuestion()
    {
        ItemSO item = selectedItem;
        int amount = int.Parse(itemAmount.text);
        int total = int.Parse(totalPrice.text);

        Debug.Log("**Item:** " + item.itemName);
        Debug.Log("**Amount:** " + amount);
        Debug.Log("**Total:** " + total);

        questionListUI.DisplayQuestion(item, amount, total);
    }
}
