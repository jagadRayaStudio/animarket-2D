using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreItemUI : MonoBehaviour
{
    public Image itemIcon;
    private int cost;
    public TMP_Text itemName;
    private string itemDesc;

    public Button itemButton;

    public void SetStoreItem(ItemSO _item, TransactionUI transactionUI)
    {
        itemIcon.sprite = _item.sprite;
        itemName.text = _item.itemName;
        cost = _item.cost;
        itemDesc = _item.itemDesc;

        itemButton.onClick.AddListener(() => TransactionUI.Instance.SetSelectedItem(_item));
    }
}
