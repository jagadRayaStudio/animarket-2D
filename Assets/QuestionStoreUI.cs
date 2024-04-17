using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionStoreUI : MonoBehaviour
{
    public GameObject ItemParent;
    public Button ItemPrefab;

    public GameObject QM_Stores;
    public GameObject QM_Items;
    public GameObject QM_Setup;

    public Button BackButton;

    private ItemSO selectedItem;

    public static QuestionStoreUI Instance { get; private set; }

    private List<Button> storeItems = new List<Button>();

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

        QM_Items.SetActive(false);
        QM_Setup.SetActive(false);
    }

    public void DisplayItems(StoreSO storeData)
    {
        QM_Stores.SetActive(false);
        QM_Items.SetActive(true);

        ClearChildren(ItemParent);

        foreach (var storeItemData in storeData.storeItems)
        {
            Button storeItemObject = Instantiate(ItemPrefab, ItemParent.transform);
            //storeItemObject.GetComponent<QMItemUI>().SetStoreItem(storeItemData, GetComponent<SetupItemUI>());
            storeItemObject.onClick.AddListener(() => SelectedItem(storeItemData));
            storeItems.Add(storeItemObject);
        }

        BackButton.onClick.AddListener(() => {
            QM_Items.SetActive(false);
            QM_Stores.SetActive(true);
        });
    }

    private void ClearChildren(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void SelectedItem(ItemSO selectedItem)
    {
        this.selectedItem = selectedItem;

        QM_Items.SetActive(false);
        QM_Setup.SetActive(true);

        //SetupItemUI.Instance.SetSelectedItem(selectedItem);
    }
}
