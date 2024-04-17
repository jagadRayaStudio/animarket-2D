using UnityEngine;

public class LobbyUITween : MonoBehaviour
{
    public CanvasGroup overlay;

    [SerializeField] private Transform MainPanel;
    [SerializeField] private GameObject NotifBox;
    [SerializeField] private GameObject TutorialPanel;
    [SerializeField] private Transform RoomPanel;

    private CanvasGroup _overlay;

    private string NotifText;

    public void Start()
    {
        TutorialPanel.transform.localScale = Vector2.zero;
        NotifBox.transform.localScale = Vector2.zero;
        RoomPanel.transform.localScale = Vector2.zero;
    }

    public void OpenTutor()
    {
        InstantiateOverlay();

        TutorialPanel.SetActive(true);
        TutorialPanel.transform.LeanScale(Vector2.one, 0.4f).setEaseInOutQuart();
    }

    public void CloseTutor()
    {
        TutorialPanel.transform.LeanScale(Vector2.zero, 0.4f).setEaseInBack();
        DestroyOverlay();
    }


    public void OpenNotifBox()
    {
        InstantiateOverlay();

        NotifBox.SetActive(true);
        NotifBox.transform.LeanScale(Vector2.one, 0.4f).setEaseInOutQuart();
        NotifText = ("Ayo Masukkan Nama Kelas Dulu, Ya!");
        NotifBoxUI.instance.SetNotif(NotifText);
    }

    public void CloseNotifBox()
    {
        NotifBox.transform.LeanScale(Vector2.zero, 0.4f).setEaseInBack();
        DestroyOverlay();
    }

    public void OpenRoomPanel()
    {
        InstantiateOverlay();
        
        RoomPanel.gameObject.SetActive(true);
        LeanTween.scale(RoomPanel.gameObject, new Vector2(0.7f, 0.7f), 0.4f).setEase(LeanTweenType.easeInOutQuart);
    }

    public void CloseRoomPanel()
    {
        DestroyOverlay();
        RoomPanel.transform.LeanScale(Vector2.zero, 0.4f).setEaseInBack();
    }

    public void InstantiateOverlay()
    {
        _overlay = Instantiate(overlay, MainPanel);
        _overlay.transform.SetSiblingIndex(2);
        _overlay.LeanAlpha(1, 0.4f);
    }

    public void DestroyOverlay()
    {
        _overlay.LeanAlpha(0, 0.4f);
        Destroy(_overlay.gameObject, 0.5f);
    }
}
