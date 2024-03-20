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
        GameObject newQuestion = Instantiate(QuestionPrefab, QuestionParent.transform);
        newQuestion.GetComponent<QuestionUI>().SetQuestion(item, amount, total);
    }

}
