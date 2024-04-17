using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public TMP_InputField usernameInput;
    public MainMenuUITween uiTween;

    private const string playerNameKey = "PlayerName";

    void Start()
    {
        if (PlayerPrefs.HasKey(playerNameKey))
        {
            string savedName = PlayerPrefs.GetString(playerNameKey);
            usernameInput.text = savedName;
        }
    }

    public void OnClickConnect()
    {
        if (usernameInput.text.Length >= 1)
        {
            PhotonNetwork.NickName = usernameInput.text;
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();

            //SavePlayerName
            PlayerPrefs.SetString(playerNameKey, usernameInput.text);
        }
        else
        {
            uiTween.OpenNotifBox();
        }
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("1 Lobby");
    }
}
