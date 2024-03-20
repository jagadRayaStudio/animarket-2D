using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QMItemUI : MonoBehaviour
{
    public Image itemIcon;
    private int cost;
    public TMP_Text itemName;
    private string itemDesc;

    public Button itemButton;

    public void SetStoreItem(ItemSO _item, SetupItemUI setupitemUI)
    {
        itemIcon.sprite = _item.sprite;
        itemName.text = _item.itemName;
        cost = _item.cost;
        itemDesc = _item.itemDesc;

        itemButton.onClick.AddListener(() => SetupItemUI.Instance.SetSelectedItem(_item));
    }
}
