using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun.UtilityScripts;

[System.Serializable]
public class QuestionData
{
    public static QuestionData Instance;

    public string itemName;
    public Sprite icon;
    public int cost;
    public int grandTotal;
    public int amount;
    private void Awake()
    {
        Instance = this;
    }
}

public class QuestionManager : MonoBehaviour
{
    public List<QuestionData> questionDataList = new List<QuestionData>();

    private void Start()
    {
        QuestionMakerUI.instance.storeList.SetActive(true);
        QuestionMakerUI.instance.itemList.SetActive(false);
        QuestionMakerUI.instance.AddQuestionBtn.gameObject.SetActive(true);

        QuestionMakerUI.instance.AddQuestionBtn.onClick.AddListener(AddQuestion);
        QuestionMakerUI.instance.DecreaseBtn.onClick.AddListener(DecreaseQuestion);

        QuestionMakerUI.instance.BackButton2.onClick.AddListener(() =>
        {
            QuestionMakerUI.instance.itemList.SetActive(false);
            QuestionMakerUI.instance.storeList.SetActive(true);
        });
    }

    public void AddQuestion()
    {
        QuestionData questionData = new QuestionData();
        questionDataList.Add(questionData);

        GameObject newQuestion = Instantiate(QuestionMakerUI.instance.QuestionPrefab.gameObject,
            QuestionMakerUI.instance.QuestionParent.transform);

        if (questionDataList.Count == 10) //Deactive AddBtn
        {
            QuestionMakerUI.instance.AddQuestionBtn.gameObject.SetActive(false);
        }
    }
    private void DecreaseQuestion()
    {
        if (questionDataList.Count > 0)
        {
            QuestionData lastQuestion = questionDataList[questionDataList.Count - 1];
            questionDataList.Remove(lastQuestion);
            //Destroy(lastQuestion);
        }
    }
    public void DisplayItems(StoreSO storeSO)
    {
        QuestionMakerUI.instance.storeList.gameObject.SetActive(false);
        QuestionMakerUI.instance.itemList.gameObject.SetActive(true);

        ClearChildren(QuestionMakerUI.instance.itemList);

        // Generate Item
        foreach (var storeItemData in storeSO.storeItems)
        {
            Button storeItemObject = Instantiate(QuestionMakerUI.instance.itemPrefab,
              QuestionMakerUI.instance.itemList.transform);
            storeItemObject.GetComponent<QMItemUI>().SetStoreItem(storeItemData);

            storeItemObject.onClick.AddListener(() =>
            SetupManager.Instance.UpdateQuestion(storeItemData));
        }
    }

    public void UpdateDataList()
    {

    }    

    private void ClearChildren(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
        }
    }
}

