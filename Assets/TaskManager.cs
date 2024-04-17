using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Task
{
    public ItemSO product;
    public float cost;
    public float amount;
    public float totalPrice;
    public bool bought;

    public Task(ItemSO product, float cost, float amount, float totalPrice)
    {
        this.product = product;
        this.amount = amount;
        this.cost = cost;
        this.totalPrice = totalPrice;
    }
}
public class TaskManager : MonoBehaviour
{

    public static TaskManager instance;

    public List<Task> generatedTasks = new List<Task>();

    public List<ItemSO> sayurProducts;
    public List<ItemSO> buahProducts;
    public List<ItemSO> ikanProducts;
    
    public GameObject taskPrefab;
    public Transform taskListParent;

    public GameObject successPanel;

    public int minRandomValue = 2;
    public int maxRandomValue = 10;

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GenerateRandomProducts(10);
        GenerateTaskPrefabs();
    }

    void GenerateRandomProducts(int count)
    {
        HashSet<ItemSO> generatedProducts = new HashSet<ItemSO>();

        while (generatedTasks.Count < count)
        {
            ItemSO randomProduct = GetRandomProduct();

            if (!generatedProducts.Contains(randomProduct))
            {
                int randomMultiplier = Random.Range(minRandomValue, maxRandomValue + 1);
                float totalPrice = randomProduct.cost * randomMultiplier;

                generatedTasks.Add(new Task(randomProduct, randomProduct.cost, randomMultiplier, totalPrice));
                generatedProducts.Add(randomProduct);
            }
        }
    }

    void GenerateTaskPrefabs()
    {
        foreach (Task task in generatedTasks)
        {
            GameObject taskObject = Instantiate(taskPrefab, taskListParent.transform);
            TaskUI taskUI = taskObject.GetComponent<TaskUI>();

            taskObject.LeanScale(Vector2.zero, 0.5f);
            taskObject.LeanScale(new Vector2(0.8f, 0.8f), 1f).setEaseInOutQuart();

            taskUI.SetTask(task);
        }
    }

    ItemSO GetRandomProduct()
    {
        float totalCategories = sayurProducts.Count + buahProducts.Count + ikanProducts.Count;
        float randomValue = Random.value * totalCategories;

        if (randomValue < sayurProducts.Count)
        {
            return sayurProducts[Random.Range(0, sayurProducts.Count)];
        }
        else if (randomValue < sayurProducts.Count + buahProducts.Count)
        {
            return buahProducts[Random.Range(0, buahProducts.Count)];
        }
        else
        {
            return ikanProducts[Random.Range(0, ikanProducts.Count)];
        }
    }
    public void CheckAnswer()
    {
        ItemSO selectedItem = TransactionUI.Instance.selectedItem;
        float inputAmount = float.Parse(TransactionUI.Instance.itemAmount.text);
        float inputTotalPrice = float.Parse(TransactionUI.Instance.totalPrice.text);

        Task matchingTask = null;

        foreach (Task task in generatedTasks)
        {
            if (selectedItem == task.product && inputAmount == task.amount
                && Mathf.Approximately(inputTotalPrice, task.totalPrice))
            {
                matchingTask = task;
                break;
            }
        }

        if (matchingTask != null)
        {
            matchingTask.bought = true;

            GameUITween.Instance.OpenSuccessPanel();
            SuccessPanelUI.Instance.SetItem(matchingTask);

            GetComponent<LeaderboardManager>().UpdatePlayerPoints(PhotonNetwork.LocalPlayer.NickName, 100);

            DestroyTaskPrefab(matchingTask);
        }
        else
        {
            string notifText = "Yah, sepertinya kamu salah beli produk atau menghitung, ayo coba lagi!";
            GameUITween.Instance.OpenNotifBox(notifText);
        }

        GameUITween.Instance.CloseStorePanel();
        GameUITween.Instance.CloseTransactionPanel();
    }


    void DestroyTaskPrefab(Task task)
    {
        foreach (Transform child in taskListParent)
        {
            TaskUI taskUI = child.GetComponent<TaskUI>();
            if (taskUI != null && taskUI.task == task)
            {
                Destroy(child.gameObject);
                break;
            }
        }
    }

}
