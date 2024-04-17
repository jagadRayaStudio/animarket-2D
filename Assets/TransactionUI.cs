using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TransactionUI : MonoBehaviour
{
    public Image itemIcon;
    public TMP_Text itemName;
    public TMP_Text itemDesc;
    public TMP_Text itemPrice;
    public TMP_InputField itemAmount;
    public TMP_InputField totalPrice;

    public Button BuyBtn;

    public ItemSO selectedItem;

    public static TransactionUI Instance;

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

        GameUITween.Instance.OpenTransactionPanel();
    }

}
