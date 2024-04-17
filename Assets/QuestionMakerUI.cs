using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class QuestionMakerUI : MonoBehaviour
{
    public static QuestionMakerUI instance;

    public GameObject QuestionParent;
    public GameObject QuestionPrefab;
    public GameObject mainPanel;
    public GameObject storeList;
    public GameObject itemList;

    public Button AddQuestionBtn;
    public Button DecreaseBtn;
    public Button itemPrefab;
    public Button BackButton;
    public Button BackButton2;
    private void Awake()
    {
        instance = this;
        itemList.gameObject.SetActive(false);
    }
}
