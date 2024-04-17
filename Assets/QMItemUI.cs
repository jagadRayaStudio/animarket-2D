using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QMItemUI : MonoBehaviour
{
    public static QMItemUI instance;

    public Image itemIcon;
    public int cost;
    public TMP_Text itemName;
    public string itemDesc;

    private void Awake()
    {
        instance = this;
    }

    public void SetStoreItem(ItemSO item)
    {
        itemIcon.sprite = item.sprite;
        itemName.text = item.itemName;
        cost = item.cost;
        itemDesc = item.itemDesc;
    }
}
