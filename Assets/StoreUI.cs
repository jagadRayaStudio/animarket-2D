using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreUI : MonoBehaviour
{
    public GameObject ItemParent;
    public GameObject ItemPrefab;
    public TMP_Text storeName;

    public static StoreUI Instance { get; private set; }

    private List<GameObject> storeItems = new List<GameObject>();

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

    public void DisplayStore(StoreSO storeData)
    {
        ClearChildren(ItemParent);

        storeName.text = storeData.storeName;

        foreach (var storeItemData in storeData.storeItems)
        {
            GameObject storeItemObject = Instantiate(ItemPrefab, ItemParent.transform);
            storeItemObject.GetComponent<StoreItemUI>().SetStoreItem(storeItemData, GetComponent<TransactionUI>());
            storeItems.Add(storeItemObject);
        }
    }

    private void ClearChildren(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
