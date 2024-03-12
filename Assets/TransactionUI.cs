using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TransactionUI : MonoBehaviour
{
    public Image itemIcon;
    public TMP_Text itemName;
    public TMP_Text itemDesc;
    public TMP_Text itemPrice;
    public TMP_InputField itemAmount;
    public TMP_InputField totalPrice;

    public GameObject transactionPanel;
    public GameObject successPanel;
    public GameObject failedPanel;

    private ItemSO selectedItem;

    public static TransactionUI Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        transactionPanel.SetActive(false);
    }

    public void SetSelectedItem(ItemSO item)
    {
        selectedItem = item;
        itemIcon.sprite = selectedItem.sprite;
        itemName.text = selectedItem.itemName;
        itemDesc.text = selectedItem.itemDesc.ToString();
        itemPrice.text = selectedItem.cost.ToString();

        transactionPanel.SetActive(true);
    }

}
