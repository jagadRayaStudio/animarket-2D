using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;

public class NotifBoxUI : MonoBehaviour
{
    public static NotifBoxUI instance;

    public TMP_Text Text;
    public Button CloseBtn;

    public void Awake()
    {
        instance = this;
    }

    public void SetNotif(string notifText)
    {
        Text.text = notifText;
    }

}
