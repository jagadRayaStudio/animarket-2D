using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Collections.Generic;
public class StoreManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject storeCue;
    public GameObject storePanel;
    public Button interactButton;
    public Button closeBtn;
    public Button BuyBtn;

    public StoreSO storeData;

    [SerializeField] private TransactionUI transaction;

    private bool PlayerInRange;
    public bool isStoreUsed = false;

    private List<GameObject> storeItems = new List<GameObject>();

    private void Awake()
    {
        PlayerInRange = false;
        storeCue.SetActive(false);
        storePanel.SetActive(false);

        interactButton.onClick.AddListener(InteractWithStore);
        closeBtn.onClick.AddListener(ExitStorePanel);
        BuyBtn.onClick.AddListener(CheckAnswer);
    }

    private void Update()
    {
        if (PlayerInRange)
        {
            storeCue.SetActive(true);
        }
        else
        {
            storeCue.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerInRange = false;
        }
    }

    private void InteractWithStore()
    {
        if (PlayerInRange && !isStoreUsed)
        {
            photonView.RPC("SetStoreUsedRPC", RpcTarget.AllBuffered, true);

            storePanel.SetActive(!storePanel.activeSelf);
            GameUITween.Instance.OpenStorePanel();
            DisplayStore(storeData);
            
        }
        else
        {
            string notifText = "Yah, Toko sedang dipakai teman kamu. Ayo cari toko lain!";
            GameUITween.Instance.OpenNotifBox(notifText);
        }
    }

    public void DisplayStore(StoreSO storeData)
    {
        ClearChildren(StoreUI.Instance.ItemParent);

        StoreUI.Instance.storeName.text = storeData.storeName;

        foreach (var storeItemData in storeData.storeItems)
        {
            GameObject storeItemObject = Instantiate(StoreUI.Instance.ItemPrefab, StoreUI.Instance.ItemParent.transform);

            storeItemObject.LeanScale(Vector2.zero, 0f);
            storeItemObject.LeanScale(Vector2.one, 0.5f).setEaseInOutQuart();

            SetStoreItem(storeItemData);
            storeItems.Add(storeItemObject);
        }
    }

    public void SetStoreItem(ItemSO _item)
    {
        StoreItemUI.Instance.itemIcon.sprite = _item.sprite;
        StoreItemUI.Instance.itemName.text = _item.itemName;
        StoreItemUI.Instance.cost = _item.cost;
        StoreItemUI.Instance.itemDesc = _item.itemDesc;

        StoreItemUI.Instance.itemButton.onClick.AddListener(() => transaction.SetSelectedItem(_item));
    }

    private void ClearChildren(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    [PunRPC]
    private void SetStoreUsedRPC(bool used)
    {
        isStoreUsed = used;
    }


    public void ExitStorePanel()
    {
        if (isStoreUsed)
        {
            photonView.RPC("SetStoreUsedRPC", RpcTarget.AllBuffered, false);
            GameUITween.Instance.CloseStorePanel();
        }
    }

    public void CheckAnswer()
    {
        if (isStoreUsed)
        {
            TaskManager.instance.CheckAnswer();
            photonView.RPC("SetStoreUsedRPC", RpcTarget.AllBuffered, false);
        }
    }
}
