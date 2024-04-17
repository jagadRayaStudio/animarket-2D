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

    public Button backBtn;
    public Button CreateQuestionButton;

    public static SetupItemUI Instance;

    private void Awake()
    {
        Instance = this;
    }
}
