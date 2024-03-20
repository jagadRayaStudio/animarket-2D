using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionUI : MonoBehaviour
{
    public Image itemIcon;
    public TMP_Text itemName;
    private TMP_Text itemDesc;
    public TMP_Text itemPrice;
    public TMP_Text itemAmount;
    private TMP_Text totalPrice;

    public void SetQuestion(ItemSO item, int amount, int total)
    {
        itemIcon.sprite = item.sprite;
        itemName.text = item.itemName;
        itemDesc.text = item.itemDesc.ToString();
        itemPrice.text = item.cost.ToString();
        itemAmount.text = amount.ToString();
        totalPrice.text = total.ToString();
    }
}
