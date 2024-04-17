using Unity.VisualScripting;
using UnityEngine;

public class GameUITween : MonoBehaviour
{
    public CanvasGroup overlay;

    public static GameUITween Instance;

    [SerializeField] private Transform MainPanel;
    [SerializeField] private GameObject NotifBox;
    [SerializeField] private GameObject storePanel;
    [SerializeField] private GameObject transactionPanel;
    [SerializeField] private GameObject TaskPanel;
    [SerializeField] private GameObject TutorPanel;
    [SerializeField] private GameObject successPanel;


    private CanvasGroup _overlay;

    public void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        NotifBox.transform.localScale = Vector2.zero;
        storePanel.transform.localScale = Vector2.zero;
        transactionPanel.transform.localScale = Vector2.zero;
        TaskPanel.transform.localScale = Vector2.zero;
        TutorPanel.transform.localScale = Vector2.zero;
        successPanel.transform.localScale = Vector2.zero;
        
        OpenTutorPanel();
    }

    //Tutor
    public void OpenTutorPanel()
    {
        InstantiateOverlay();

        TutorPanel.SetActive(true);
        TutorPanel.transform.LeanScale(Vector2.one, 0.5f).setEaseInOutQuart();
    }

    public void CloseTutorPanel()
    {
        TutorPanel.transform.LeanScale(Vector2.zero, 0.4f).setEaseInBack();
        DestroyOverlay();
    }

    //Task Panel
    public void OpenTaskPanel()
    {
        TaskPanel.SetActive(true);
        TaskPanel.LeanScale(Vector2.one, 0.5f).setEaseInOutQuart();
    }

    public void CloseTaskPanel()
    {
        TaskPanel.LeanScale(Vector2.zero, 0.4f).setEaseInBack();
        DestroyOverlay();
    }

    //Win Condition
    public void OpenSuccessPanel()
    {
        successPanel.SetActive(true);
        successPanel.LeanScale(Vector2.one, 0.5f).setEaseInOutExpo();
    }

    public void CloseSuccessPanel()
    {
        successPanel.LeanScale(Vector2.zero, 0.4f).setEaseInBack();
        DestroyOverlay();
    }

    //StorePanel
    public void OpenStorePanel()
    {
        InstantiateOverlay();

        storePanel.SetActive(true);
        storePanel.LeanScale(Vector2.one, 0.5f).setEaseInOutQuart();
    }

    public void CloseStorePanel()
    {
        storePanel.LeanScale(Vector2.zero, 0.4f).setEaseInBack();
        DestroyOverlay();
    }

    //StorePanel
    public void OpenTransactionPanel()
    {
        transactionPanel.SetActive(true);

        transactionPanel.LeanScale(Vector2.one, 0.5f).setEaseInOutQuart();
    }

    public void CloseTransactionPanel()
    {
        transactionPanel.LeanScale(Vector2.zero, 0.4f).setEaseInBack();

        TransactionUI.Instance.itemAmount.text = string.Empty;
        TransactionUI.Instance.totalPrice.text = string.Empty;
        DestroyOverlay();
    }

    //Notif Box
    public void OpenNotifBox(string notifText)
    {
        NotifBox.SetActive(true);
        NotifBox.transform.LeanScale(Vector2.one, 0.5f).setEaseInOutQuart();
        NotifBoxUI.instance.SetNotif(notifText);
    }

    public void CloseNotifBox()
    {
        NotifBox.transform.LeanScale(Vector2.zero, 0.4f).setEaseInBack();
        DestroyOverlay();
    }

    public void InstantiateOverlay()
    {
        _overlay = Instantiate(overlay, MainPanel);
        _overlay.transform.SetSiblingIndex(1);
        _overlay.LeanAlpha(1, 0.4f);
    }

    public void DestroyOverlay()
    {
        _overlay.LeanAlpha(0, 0.4f);
        Destroy(_overlay.gameObject, 0.5f);
    }
}
