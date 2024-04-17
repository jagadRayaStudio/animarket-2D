using UnityEngine;

public class MainMenuPanelUI : MonoBehaviour
{
    public static MainMenuPanelUI instance;

    public GameObject TutorialPanel;
    public GameObject NotifPanel;

    public void Awake()
    {
        instance = this;
    }
}
