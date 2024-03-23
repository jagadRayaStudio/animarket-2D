using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionListUI : MonoBehaviour
{
    public GameObject QuestionParent;
    public GameObject QuestionPrefab;

    public static QuestionListUI Instance { get; private set; }

    private List<GameObject> questionData = new List<GameObject>();

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
    }

    public void DisplayQuestion(ItemSO item, int amount, int total)
    {
        if (questionData.Count <= 10)
        {
            GameObject newQuestion = Instantiate(QuestionPrefab, QuestionParent.transform);
            QuestionUI questionUI = newQuestion.GetComponent<QuestionUI>();
            questionUI.SetQuestion(item, amount, total);
            questionData.Add(newQuestion);

            Debug.Log("**Displaying Question:**");
            Debug.Log("**Item:** " + item.itemName);
            Debug.Log("**Amount:** " + amount);
            Debug.Log("**Total:** " + total);
            Debug.Log("**Jumlah Question Data:** " + questionData.Count);
        }
    }

}
